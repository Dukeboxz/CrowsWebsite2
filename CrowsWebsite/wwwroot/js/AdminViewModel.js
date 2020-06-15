AdminViewModel = function (data) {

    var self = this;
    ko.mapping.fromJS(data, {}, self);

    function GetMembertabContents() {

        var url = $('#GetMemberTabUrl').val(); 

        $.ajax({
            url: url,
            data: {},
            type: 'POST',
            success: function (data) {

                $('#tabContents').html("");
                $('#tabContents').html(data)

            }, error: function (error) {

                $('#tabContents').html("");
                $('#tabContents').html("<p>There was an error getting data please try again</p>")
            }

        })

    }

    function GetGameNightTabContent() {

        var url = $('#GetGameNightTabUrl').val();

        $.ajax({
            url: url,
            data: {},
            type: 'POST',
            success: function (data) {

                $('#tabContents').html("");
                $('#tabContents').html(data);

            }, error: function (error) {

                $('#tabContents').html("");
                $('#tabContents').html("<p>There was an error getting data please try again</p>");
            }

        })
    }

    self.ShowModalToAddGameNight = function () {

    }

    $(function () {


        $('.adminNav').on("click", function (e) {

            var id = $(this).attr("data_id");
            if (id === "1") {

                $('#MemberTab').removeClass("active");
                $('#GameNightTab').addClass("active");

                GetGameNightTabContent();

                //$('#tabContents').html(""); 
                //$('#tabContents').html("<p>Game night tab</p>")

            } else {

                $('#GameNightTab').removeClass("active");
                $('#MemberTab').addClass("active");

                GetMembertabContents();

                //$('#tabContents').html("");
                //$('#tabContents').html("<p>Member tab</p>")
            }

          
        });

    });

    $(function () {

        $('#gameNightDate').datepicker();

    });

}