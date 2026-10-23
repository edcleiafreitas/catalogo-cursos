const el = {
  faixa: document.getElementById("carrossel-lista"),
  estadoCarrossel: document.getElementById("carrossel-estado"),
  anterior: document.getElementById("seta-anterior"),
  proxima: document.getElementById("seta-proxima"),
  form: document.getElementById("form-filtros"),
  busca: document.getElementById("busca"),
  categoria: document.getElementById("filtro-categoria"),
  modalidade: document.getElementById("filtro-modalidade"),
  status: document.getElementById("filtro-status"),
  limpar: document.getElementById("limpar"),
  contagem: document.getElementById("contagem"),
  regiao: document.getElementById("resultados"),
  grade: document.getElementById("grade"),
  estado: document.getElementById("estado")
};

let controle = null; // cancela a busca anterior se o usuário digitar rápido
let temporizador = null;

function preencherSelect(select, opcoes) {
  opcoes.forEach(function (op) {
    const option = document.createElement("option");
    option.value = op.valor;
    option.textContent = op.texto;
    select.appendChild(option);
  });
}

async function carregarFiltros() {
  try {
    const dados = await buscarJson("/api/filtros");
    preencherSelect(el.categoria, dados.categorias.map(function (c) { return { valor: c.id, texto: c.nome }; }));
    preencherSelect(el.modalidade, dados.modalidades.map(function (m) { return { valor: m, texto: m }; }));
    preencherSelect(el.status, dados.status.map(function (s) { return { valor: s, texto: s }; }));
  } catch (e) {
    // Sem os filtros a busca por nome ainda funciona; o erro principal aparece na listagem.
  }
}

async function carregarCarrossel() {
  mostrarCarregando(el.estadoCarrossel, "Carregando principais cursos…");
  try {
    const dados = await buscarJson("/api/cursos");
    el.estadoCarrossel.replaceChildren();
    el.faixa.replaceChildren();
    dados.cursos.slice(0, 5).forEach(function (curso) { el.faixa.appendChild(criarCard(curso)); });
  } catch (e) {
    mostrarEstado(el.estadoCarrossel, "Não foi possível carregar os principais cursos",
      "Verifique sua conexão e tente de novo.", "Tentar novamente", carregarCarrossel, true);
  }
}

function montarConsulta() {
  const p = new URLSearchParams();
  if (el.busca.value.trim()) p.set("busca", el.busca.value.trim());
  if (el.categoria.value) p.set("categoria", el.categoria.value);
  if (el.modalidade.value) p.set("modalidade", el.modalidade.value);
  if (el.status.value) p.set("status", el.status.value);
  const texto = p.toString();
  return "/api/cursos" + (texto ? "?" + texto : "");
}

function textoContagem(total) {
  return total === 1 ? "1 curso encontrado" : total + " cursos encontrados";
}

async function carregarLista() {
  if (controle) controle.abort();
  controle = new AbortController();
  const sinal = controle.signal;

  el.regiao.setAttribute("aria-busy", "true");
  el.grade.replaceChildren();
  el.contagem.textContent = "Buscando cursos…";
  mostrarCarregando(el.estado, "Carregando cursos…");

  try {
    const dados = await buscarJson(montarConsulta(), { signal: sinal });
    el.estado.replaceChildren();
    el.contagem.textContent = textoContagem(dados.total);

    if (dados.total === 0) {
      mostrarEstado(el.estado, "Nenhum curso encontrado",
        "Tente outro nome ou remova algum filtro para ver mais opções.",
        "Limpar filtros", limparFiltros, false);
    } else {
      dados.cursos.forEach(function (curso) { el.grade.appendChild(criarCard(curso)); });
    }
  } catch (e) {
    if (e.name === "AbortError") return; // uma busca mais nova já está em andamento
    el.contagem.textContent = "Não foi possível carregar os cursos";
    mostrarEstado(el.estado, "Não foi possível carregar os cursos",
      "O servidor não respondeu. Verifique sua conexão e tente novamente.",
      "Tentar novamente", carregarLista, true);
  } finally {
    if (!sinal.aborted) el.regiao.setAttribute("aria-busy", "false");
  }
}

function limparFiltros() {
  el.form.reset();
  carregarLista();
  el.busca.focus();
}

el.form.addEventListener("submit", function (ev) {
  ev.preventDefault();
  clearTimeout(temporizador);
  carregarLista();
});
el.busca.addEventListener("input", function () {
  clearTimeout(temporizador);
  temporizador = setTimeout(carregarLista, 300);
});
[el.categoria, el.modalidade, el.status].forEach(function (s) { s.addEventListener("change", carregarLista); });
el.limpar.addEventListener("click", limparFiltros);

el.anterior.addEventListener("click", function () { el.faixa.scrollBy({ left: -el.faixa.clientWidth * 0.8, behavior: "smooth" }); });
el.proxima.addEventListener("click", function () { el.faixa.scrollBy({ left: el.faixa.clientWidth * 0.8, behavior: "smooth" }); });

carregarFiltros();
carregarCarrossel();
carregarLista();
