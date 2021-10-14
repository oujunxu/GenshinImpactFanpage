const quizData = [
    {
        question: "1. What is the name of the traveller in Genshin Impact?",
        a: "Aether/Lumine",
        b: "Adam/Lumine",
        c: "Diluc/Signoria",
        d: "Tartaglia/Mona",
        correct: "a"
    },

    {
        question: "2. Which type of weapon does the traveller use?",
        a: "Polearm/Spear",
        b: "Great Sword",
        c: "Sword",
        d: "Catalyst",
        correct: "c"
    },

    {
        question: "3. Who are the composer of many of Genshin Impacts original sound tracks?",
        a: "HoyoLab",
        b: "Hoyo-Mix",
        c: "Sawano Hiroyuki",
        d: "Selen",
        correct: "b"
    },
    {
        question: "4. When does Genshin Impact celebrate their anniversary?",
        a: "Jan 5th",
        b: "Oct 2nd",
        c: "Sep 28th",
        d: "Dec 13th",
        correct: "c"
    },
    {
        question: "5. What is the name of the snow area?",
        a: "Liyue",
        b: "Monstadth",
        c: "Inazuma",
        d: "Dragonspine",
        correct: "d"
    }
];

// variables to change the value of the html elements to those written in quizData.
const quiz = document.getElementById('quiz')
const answerEls = document.querySelectorAll('.answer') // insert all the input elements with class name: answer into a list.
const questionEl = document.getElementById('question')
const a_text = document.getElementById('a_text')
const b_text = document.getElementById('b_text')
const c_text = document.getElementById('c_text')
const d_text = document.getElementById('d_text')
const submitBtn = document.getElementById('submit')

let currentQuiz = 0
let score = 0

loadQuiz()

function loadQuiz() {

    deselectAnswers()

    const currentQuizData = quizData[currentQuiz]

    questionEl.innerText = currentQuizData.question
    a_text.innerText = currentQuizData.a
    b_text.innerText = currentQuizData.b
    c_text.innerText = currentQuizData.c
    d_text.innerText = currentQuizData.d
}

// deselction method 
function deselectAnswers() { // works the same as foreach(var answerEl in answerEls){ answerEL.checked = false};
    answerEls.forEach(answerEl => answerEl.checked = false) // loop through every radio buttons and uncheck them.
}

function getSelected() {
    let answer
    answerEls.forEach(answerEl => { // foreach(var answerEl in answerEls){ if-statement };
        if (answerEl.checked) {
            answer = answerEl.id
        }
    })
    return answer
}


submitBtn.addEventListener('click', () => {
    const answer = getSelected()
    if (answer) {
        if (answer === quizData[currentQuiz].correct) {
            score++
        }
        currentQuiz++

        if (currentQuiz < quizData.length) { // when there's questions left.
            loadQuiz() //load the next quiz.
        } else {
            // inserts one html tag, h2 and an onclick method/function.  
            // location.reload() = reload the page/url.
            quiz.innerHTML = ` 
           <h2>You answered ${score}/${quizData.length} questions correctly</h2>

           <button class="btn-reload" onclick="location.reload()">Reload</button>
           `
        }
    }
})
