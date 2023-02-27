let winners = [];

const matrix = [
  Array.from(document.getElementsByClassName("cardboardOne")),
  Array.from(document.getElementsByClassName("cardboardTwo")),
  Array.from(document.getElementsByClassName("cardboardThree")),
  Array.from(document.getElementsByClassName("cardboardFour")),
];

let cardboards = matrix.map((matrix) => {
  const [id, ...content] = matrix;
  return {
    id: id,
    content: content,
  };
});

document.getElementById("throwBall").addEventListener("click", async () => {
  document.getElementById("throwBall").disabled = true;
  document.getElementById("throwBall").textContent === "Jugar de nuevo"
    ? location.reload()
    : (setColorCardboards(await generateBallNumber()), getWinningCardboard());
  if (winners.length > 0) {
    document.getElementById("throwBall").textContent = "Jugar de nuevo";
    await sendWinners(winners);
    showWinners();
  }
  document.getElementById("throwBall").disabled = false;
});

async function generateBallNumber() {
  try {
    const response = await fetch("/Home/GenerateNumber", { method: "GET" });
    const randomNumber = await response.text();
    document.getElementById("seeResult").innerHTML = randomNumber.padStart(
      2,
      "0"
    );
    return randomNumber.padStart(2, "0");
  } catch (error) {
    console.error(error);
  }
}
async function sendWinners(array) {
  try {
    const response = await fetch("/Home/Winners", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(array),
    });
    if (!response.ok) {
      throw new Error("Error");
    }
  } catch (error) {
    console.error(error);
  }
}

function setColorCardboards(ballNumber) {
  Object.values(cardboards).forEach((cardboard) => {
    cardboard.content = [...cardboard.content].filter((content) =>
      ballNumber === content.outerText
        ? (content.classList.add("bg-danger", "text-white"), false)
        : true
    );
  });
}

function getWinningCardboard() {
  for (const cardboard of Object.values(cardboards)) {
    if (
      cardboard.content.length == 0 &&
      !isNaN(parseInt(cardboard.id.outerText))
    ) {
      winners.push(parseInt(cardboard.id.outerText));
    }
  }
}

function showWinners() {
  for (var i = 0; i < winners.length; i++)
    document.getElementById(
      "winnersModalBody"
    ).innerHTML += `<div> Carton ${winners[i]} </div>`;
  $("#winnersModal").modal("show");
}