GameSelectionViewModel = function (data) {

    var self = this;
    ko.mapping.fromJS(data, {}, self);
    var ownedGameSuggestions = [];

    function addOwnedGameToCollection(gameId) {

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
                                value: obj.id
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

                    return game.id === ui.item.value;
                })

                self.member.ownedGames.push(selectedGame);
                
                var test = 5
            }

        })

    })
   

}