const elEstado = document.getElementById("estado");
const elCurso = document.getElementById("curso");
const elAviso = document.getElementById("aviso");
let temporizadorAviso = null;

function preencherCurso(c) {
  document.title = c.nomeBreve + " | SESI + Indústria";
  document.getElementById("chip").replaceChildren(criarChip(c.categoria));
  document.getElementById("titulo").textContent = c.nomeCompleto;
  document.getElementById("titulo-barra").textContent = c.nomeCompleto;
  document.getElementById("inicio").textContent = formatarData(c.dataDisponibilizacao);
  document.getElementById("descricao").textContent = c.descricao;

  const ficha = document.getElementById("ficha");
  ficha.replaceChildren();
  [
    ["Categoria", c.categoria],
    ["Modalidade", c.modalidade],
    ["Carga horária", c.cargaHoraria + " horas"],
    ["Público-alvo", c.publicoAlvo],
    ["Status", c.status],
    ["Disponível a partir de", formatarData(c.dataDisponibilizacao)]
  ].forEach(function (par) {
    const linha = document.createElement("div");
    linha.appendChild(criarElemento("dt", "", par[0]));
    linha.appendChild(criarElemento("dd", "", par[1]));
    ficha.appendChild(linha);
  });

  const modulos = document.getElementById("modulos");
  modulos.replaceChildren();
  c.modulos.forEach(function (m, i) {
    const bloco = document.createElement("details");
    if (i === 0) bloco.open = true;
    const resumo = document.createElement("summary");
    resumo.appendChild(criarElemento("span", "", "Módulo " + (i + 1) + ": " + m.titulo));
    [["icone-abrir", "img/icones/add_2.svg"], ["icone-fechar", "img/icones/remove.svg"]].forEach(function (p) {
      const icone = document.createElement("img");
      icone.className = p[0];
      icone.src = p[1];
      icone.alt = "";
      resumo.appendChild(icone);
    });
    bloco.appendChild(resumo);
    bloco.appendChild(criarElemento("p", "", m.descricao));
    modulos.appendChild(bloco);
  });
}

async function carregarCurso() {
  const id = parseInt(new URLSearchParams(location.search).get("id"), 10);
  if (!id) return mostrarNaoEncontrado();

  elCurso.hidden = true;
  mostrarCarregando(elEstado, "Carregando curso…");
  try {
    const curso = await buscarJson("/api/cursos/" + id);
    elEstado.replaceChildren();
    preencherCurso(curso);
    elCurso.hidden = false;
  } catch (e) {
    if (e.status === 404) return mostrarNaoEncontrado();
    mostrarEstado(elEstado, "Não foi possível carregar o curso",
      "O servidor não respondeu. Verifique sua conexão e tente novamente.",
      "Tentar novamente", carregarCurso, true);
  }
}

function mostrarNaoEncontrado() {
  mostrarEstado(elEstado, "Curso não encontrado",
    "O endereço pode estar incorreto ou o curso não está mais no catálogo.",
    "Ver todos os cursos", function () { location.href = "index.html#cursos"; }, false);
}

document.querySelectorAll("[data-matricula]").forEach(function (botao) {
  botao.addEventListener("click", function () {
    elAviso.textContent = "A matrícula não faz parte desta demonstração.";
    elAviso.hidden = false;
    clearTimeout(temporizadorAviso);
    temporizadorAviso = setTimeout(function () { elAviso.hidden = true; }, 4000);
  });
});

carregarCurso();
