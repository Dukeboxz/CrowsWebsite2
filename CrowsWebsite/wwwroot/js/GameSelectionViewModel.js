GameSelectionViewModel = function (data) {

    var self = this;
    ko.mapping.fromJS(data, {}, self);
    var ownedGameSuggestions = [];

    

    self.DeleteOwnedGame = function (game) {

        self.member.ownedGames.remove(game);
    }

    self.DeleteWantToPalyGame = function (game) {

        self.member.likeToPlayGames.remove(game)
    }

    $(function () {
        var url = $('#gameOwnedSearchUrl').val();

        $('#gameOwnedSearch').autocomplete({
            source: function (req, res) {

                var ity = 5;
                $.ajax({
                    url: url,
                    data: {
                        term: req.term
                    },
                    type: 'POST',
                    dataType: 'json',
                    success: function (data) {

                        ownedGameSuggestions = [];
                        ownedGameSuggestions = data;

                        var te = 5;
                        res($.map(data, function (obj, key) {

                            var to = 5;
                            return {
                                label: obj.name,
                                value: obj.apiId
                            }
                        }));

                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        var test = 5
                    }
                })
            },
            minLength: 4,
            select: function (event, ui) {

                var selectedGame = ownedGameSuggestions.find(game => {

                    return game.apiId === ui.item.value;
                })

                self.member.ownedGames.push(selectedGame);

                var test = 5

                return false
            }

        });


        $('#gameWantedSearch').autocomplete({
            source: function (req, res) {

                var ity = 5;
                $.ajax({
                    url: url,
                    data: {
                        term: req.term
                    },
                    type: 'POST',
                    dataType: 'json',
                    success: function (data) {

                        LikeToPlaySelection = [];
                        LikeToPlaySelection = data;

                        var te = 5;
                        res($.map(data, function (obj, key) {

                            var to = 5;
                            return {
                                label: obj.name,
                                value: obj.apiId
                            }
                        }));

                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        var test = 5
                    }
                })
            },
            minLength: 4,
            select: function (event, ui) {

                var selectedGame = LikeToPlaySelection.find(game => {

                    return game.apiId === ui.item.value;
                })

                self.member.likeToPlayGames.push(selectedGame);

                var test = 5

                return false
            }

        });

        

    })

    self.SaveAll = () => {

        var url = $('#saveAllurl').val();

        var data = ko.toJS(self.member)

        $.ajax({
            url: url,
            data: data,
            type: 'POST',
            //dataType: 'json',
            success: function (data) {

                var test = 5;

            },
            error: function (jqXHR, textStatus, errorThrown) {
                var test = 5
            }
        })


    }

}