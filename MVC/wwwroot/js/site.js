


    $(document).ready(function () {
        $("#Save").click(function () {
            let trueAnswers = [];
            var selecetedValue = "";
            for (var i = 0; i < 4; i++) {

                $("trueAnswer" + i.toString()).change(function () {

                    selecetedValue = $(this).children('option:selected').val();
                    trueAnswers.push(selecetedValue);
                })

            }
            let questions = [];
            
            for (var i = 0; i < 4; i++) {
                let answers = [];
                for (var j = 0; j < 4; j++) {
                    var IsTrueAns = selecetedValue === $("#" + j.toString() + "a").text();
                    var answer = { AnswerText: $("#" + i.toString() + j.toString()).val() }
                    if (IsTrueAns) {
                        answer.IsTrue = IsTrueAns;
                    }
                    answers.push(answer);
                }
                var question = {
                    QuestionContent: $("#" + i.toString()).val(),
                    Answers: answers
                }
                questions.push(question)
            }
            var exam = {
                Title: $("#title").val(),
                Content: $("#content").val(),
                Questions: questions
            }

            $.ajax({
                type: 'POST',
                url: '/Exam/CreateExam',
                data: exam,
                success: function (data) {
                    console.log(data)

                },
                error: function (data) {
                    console.log(data)
                }
            })

        })
    })


