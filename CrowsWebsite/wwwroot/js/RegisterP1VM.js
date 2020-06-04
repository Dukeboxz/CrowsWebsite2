RegisterP1VM = function (data) {
    var self = this;
    ko.mapping.fromJS(data, {}, self);

    saveMemberDetails = function () {

        var data = ko.toJSON(self)
        var data2 = ko.toJS(self)

        var url = $('#userParamForm1').val();
        $.post(url, data2, function (response) {
            if (response === "success") {

                window.location.href = $('#userGameSelection').val();


            } else{
                alert("failed to save details please try again");
            }
        })
    }
}