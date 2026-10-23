// Funções compartilhadas entre a página de catálogo e a de detalhes.

const CATEGORIAS = {
  "Matemática": { icone: "img/icones/icon-matematica-20px.svg", classe: "chip--matematica" },
  "Ciências da Natureza": { icone: "img/icones/icon-ciencias-natureza-20px.svg", classe: "chip--ciencias" },
  "Linguagens": { icone: "img/icones/icon-linguagens-20px.svg", classe: "chip--linguagens" },
  "Sustentabilidade": { icone: "img/icones/icon-sustentabilidade-20px.svg", classe: "chip--sustentabilidade" }
};

async function buscarJson(url, opcoes) {
  const resposta = await fetch(url, opcoes);
  if (!resposta.ok) {
    const erro = new Error("Falha na requisição: " + resposta.status);
    erro.status = resposta.status;
    throw erro;
  }
  return resposta.json();
}

function formatarData(iso) {
  if (!iso) return "A definir";
  return new Date(iso).toLocaleDateString("pt-BR");
}

function criarElemento(tag, classe, texto) {
  const el = document.createElement(tag);
  if (classe) el.className = classe;
  if (texto !== undefined) el.textContent = texto;
  return el;
}

function criarChip(nomeCategoria) {
  const info = CATEGORIAS[nomeCategoria] || { icone: "", classe: "" };
  const chip = criarElemento("span", "chip " + info.classe);
  if (info.icone) {
    const img = document.createElement("img");
    img.src = info.icone;
    img.alt = "";
    chip.appendChild(img);
  }
  chip.appendChild(document.createTextNode(nomeCategoria));
  return chip;
}

function criarCard(curso) {
  const item = criarElemento("li", "card");
  const link = criarElemento("a", "card__link");
  link.href = "curso.html?id=" + encodeURIComponent(curso.id);

  const img = document.createElement("img");
  img.className = "card__img";
  img.src = curso.imagemUrl;
  img.alt = "";
  img.loading = "lazy";
  link.appendChild(img);

  link.appendChild(criarChip(curso.categoria));
  link.appendChild(criarElemento("h3", "card__titulo", curso.nomeCompleto));
  link.appendChild(criarElemento("p", "card__descricao", curso.descricao));

  const meta = criarElemento("div", "card__meta");
  meta.appendChild(criarElemento("span", "", curso.modalidade));
  meta.appendChild(criarElemento("span", "", curso.cargaHoraria + " horas"));
  meta.appendChild(criarElemento("span", "", curso.status));
  link.appendChild(meta);

  item.appendChild(link);
  return item;
}

function mostrarCarregando(container, mensagem) {
  container.replaceChildren();
  const bloco = criarElemento("div", "carregando");
  bloco.appendChild(criarElemento("span", "giro"));
  bloco.appendChild(criarElemento("span", "", mensagem));
  container.appendChild(bloco);
}

function mostrarEstado(container, titulo, texto, rotuloBotao, aoClicar, ehErro) {
  container.replaceChildren();
  const bloco = criarElemento("div", "estado" + (ehErro ? " estado--erro" : ""));
  bloco.appendChild(criarElemento("h3", "", titulo));
  bloco.appendChild(criarElemento("p", "", texto));
  if (rotuloBotao) {
    const botao = criarElemento("button", "btn btn--preto", rotuloBotao);
    botao.type = "button";
    botao.addEventListener("click", aoClicar);
    bloco.appendChild(botao);
  }
  container.appendChild(bloco);
}
