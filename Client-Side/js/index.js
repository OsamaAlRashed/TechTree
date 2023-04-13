var Buildings = [];
var Counts = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
var MaxCounts = [];
var Costs = [];
var prolog;
var MyBuildings = [];
var myMoney = 100000;
var session = pl.create();


//زيادة المال
setInterval(() => {
    if (MyBuildings.indexOf("mine") !== -1) {

        myMoney += 100 * Counts[4];
        $('.money').html(myMoney)
        console.log(myMoney)
    }
}, (2000))


//تهيئة
$(document).ready(() => {
    $.ajax({
        url: 'https://localhost:44357/api/General/GetBuilds',
        type: 'Get',
        dataType: 'json',
    }).done((json) => {
        Buildings = json;
        console.log(Buildings);
        for (var i = 0; i < Buildings.length; i++) {
            MaxCounts.push(Buildings[i].maxCount);
            Costs.push(Buildings[i].cost);
        }
        console.log(Buildings[0])

        var html = '';
        for (var i = 0; i < Buildings.length; i++) {
            html += `
                    <div id= "${Buildings[i].buildName}" index="${i}" class=" border btn builddown" 
                        data-toggle="tooltip" data-placement="top" title="" style="width: 100%;
                    padding-left: 68px;
                    padding-right: 70px;
                            " >
                      <img class="h-100" src="../Image/Builds/${Buildings[i].buildName}.png" style="width: 100%;"/>
                     </div>
                    `
        }
        $('.down-bar').append(html);


        prolog = `
         build(commandCenter,${Costs[0]},${MaxCounts[0]}).
         build(power,${Costs[1]},${MaxCounts[1]}).
         build(barracks,${Costs[2]},${MaxCounts[2]}).
         build(defences,${Costs[3]},${MaxCounts[3]}).
         build(mine,${Costs[4]},${MaxCounts[4]}).
         build(airport,${Costs[5]},${MaxCounts[5]}).
         build(warFactory,${Costs[6]},${MaxCounts[6]}).
         build(strategyCenter,${Costs[7]},${MaxCounts[7]}).
         build(hospital,${Costs[8]},${MaxCounts[8]}).
         build(radar,${Costs[9]},${MaxCounts[9]}).
         build(nuclearPower,${Costs[10]},${MaxCounts[10]}).
         build(superWeapon,${Costs[11]},${MaxCounts[11]}).
         
         
         
         
         need(commandCenter,[]).
         need(hospital,[commandCenter]).
         need(power,[commandCenter]).
         need(barracks,[commandCenter,hospital]).
         need(defences,[power]).
         need(mine,[power]).
         need(warFactory,[mine]).
         need(airport,[mine]).
         need(strategyCenter,[mine,warFactory]).
         need(nuclearPower,[strategyCenter]).
         need(radar,[strategyCenter]).
         need(superWeapon,[nuclearPower]).
         need(nuclearPower,[strategyCenter,mine]).
         
         isMember(X,[X|T]).
         isMember(X,[H|T]):- isMember(X,T).
         
         
         % 1
         
         getAllBuildings(Result):- findall(H, build(H,_,_),Result).
         
         whatNeed(Building,NeededBuilding):- need(Building,NeededBuilding).
         
         
         isMoneyEnough(Building,MyMoney):- build(Building,Cost,_) , Cost =< MyMoney.
         
         isNotMax(Building,Count):- build(Building,_,Max) , Count < Max.
         
         isBuildingsExist(Building,MyBuildings) :- 
         need(Building,BuildingsList),
         isBuildingsExist(Building,MyBuildings,BuildingsList).
         
         %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
         
         isBuildingsExist(_,_,[]).
         
         isBuildingsExist(Building,MyBuildings,[H|T]) :- 
         isMember(H,MyBuildings) ,  
         isBuildingsExist(Building,MyBuildings,T).
         
         %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
         
         isCanBuild(Building,MyBuildings,MyMoney,Count,Needed) :- \\+(isBuildingsExist(Building,MyBuildings)) , need(Building,Needed).
         isCanBuild(Building,MyBuildings,MyMoney,Count,money) :- \\+(isMoneyEnough(Building,MyMoney)).
         isCanBuild(Building,MyBuildings,MyMoney,Count,max_count) :- \\+(isNotMax(Building,Count)).
         
         isCanBuild(Building,MyBuildings,MyMoney,Count,yes).
         
         %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
         
         whatCanBuild(MyBuildings,MyMoney,CountList , ResultList) :- 
         getAllBuildings(AllBuildings), 
         whatCanBuild(MyBuildings,AllBuildings,MyMoney,CountList , ResultList).
         
         whatCanBuild(_,[],_,[],[]).
         
         whatCanBuild(MyBuildings,[H1|Buildings],MyMoney,[H2|Counts] , Result) :-  
         isCanBuild(H1,MyBuildings,MyMoney,H2,R) , R \\== yes,
         whatCanBuild(MyBuildings,Buildings,MyMoney,Counts ,Result).
         
         
         whatCanBuild(MyBuildings,[H1|Buildings],MyMoney,[H2|Counts] , [H1|Result]) :-  
         whatCanBuild(MyBuildings,Buildings,MyMoney,Counts ,Result).
         
         %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
         
         isNeeded(H,Building):- need(H,L),isMember(Building,L).
         
         whoNeedThis(Building,Result) :- findall(H,isNeeded(H,Building),Result).
         
         
         %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
         
         
         %%whatNeedToBuild(Building,[]):- notNeed(Building).`;
    })



    $('.money').html(myMoney);

})


//الاستعلامات

$(document).on('mouseover', ".builddown", function () {
    var div = this;
    //onsole.log(div)
    // console.log(this.id)
    var id = this.id;

    var i = this.getAttribute('index');
    var title = this.getAttribute("title")
    console.log(`whoNeedThis(${id},Result).`);
    //console.log(prolog);


    session.consult(prolog, {
        success: function () {
            session.query(`whatNeed(${id},Result).`, {
                success: function (e) {
                    session.answer({
                        success: function (e) {
                            var ans = session.format_answer(e);
                            var arr = ans.substring(10, ans.length - 2).split(',');
                            //    console.log(ans);

                            session.query(`whoNeedThis(${id},NeedingBuilding).`, {
                                success: function (e) {
                                    session.answer({
                                        success: function (e) {
                                            var ans = session.format_answer(e);
                                            console.log(ans)
                                            div.setAttribute('title',
                                                `Name: ${Buildings[i].buildName}
                                                        Cost: ${Buildings[i].cost}
                                                        Max: ${Buildings[i].maxCount}
                                                        Needed Buildings: ${arr}
                                                        ${ans}`)

                                        },

                                    });
                                },
                                error: function (e) {
                                    console.log(e);
                                },
                            });


                        },
                    });
                },
                error: function (e) {
                    console.log(e);
                },
            });
        },

    });


})

$(document).on("click", ".builddown", function () {
    //  console.log(Buildings)
    var addElement = this.id;
    var index = $(this).attr('index');
    console.log(index);
    console.log(`isCanBuild(${addElement},[${MyBuildings}],${myMoney},${Counts[index]},Result).`)
    session.consult(prolog, {
        success: function () {
            session.query(`isCanBuild(${addElement},[${MyBuildings}],${myMoney},${Counts[index]},Result).`, {
                success: function (e) {
                    session.answer({
                        success: function (e) {
                            var ans = session.format_answer(e);
                            console.log(ans);
                            ans = ans.split("=");
                            var result = ans[1].trim();
                            console.log(ans[1]);
                            if (result[0] == 'y') {
                                $('.table-borderless').append(`<div class="col-2" style="height: 210px;">
                                    <img class="w-100 h-100" src="../Image/Builds/${addElement}.png" />
                                  </div>`);
                                if (MyBuildings.indexOf(addElement) === -1) {
                                    MyBuildings.push(addElement);

                                }
                                Counts[+index]++;
                                myMoney -= Costs[+index];
                                $('.money').html(myMoney)
                            }
                            else if (result[0] == '[') {
                                alert(`This Building need : ${result}`)
                            }
                            else if (result[1] == 'o') {
                                alert("Your Money is not enough.")
                            }
                            else {
                                alert("You have reached the limited to build this building.")
                            }


                        },
                    });
                },
                error: function (e) {
                    console.log(e);
                },
            });
        },
    });


});

$(document).on("click", ".whatCanBuild", function () {
    console.log(`whatCanBuild([${MyBuildings}],${myMoney},[${Counts}],Result).`)
    //console.log(prolog)
    session.consult(prolog, {
        success: function () {
            session.query(`whatCanBuild([${MyBuildings}],${myMoney},[${Counts}],Result).`, {
                success: function (e) {
                    session.answer({
                        success: function (e) {
                            var ans = session.format_answer(e);
                            console.log(ans);
                            var arr = ans.substring(10, ans.length - 3).split(',');
                            alert(arr);
                        },
                    });
                },
                error: function (e) {
                    console.log(e);
                },
            });
        },
    });
})


//تعديل المعلومات

$(".setting").on("click", function () {
    $('.selectform').empty();
    $.ajax({
        url: 'https://localhost:44357/api/General/GetBuilds',
        type: 'Get',
        dataType: 'json',
    }).done((json) => {
        console.log(json);
        for (var i = 0; i < json.length; i++) {
            $('.selectform').append(
                `<option value='${json[i].cost},${json[i].maxCount},${json[i].id},${json[i].buildName}'>${json[i].buildName}</option>`
            );

        }
        $('.costform').val(json[0].cost);
        $('.countform').val(json[0].maxCount);

    })
});

$('.saveform').on("click", function () {

    var values = $('.selectform').val().split(',');
    console.log(values);
    var buildDto = JSON.stringify({
        "id": +values[2],
        "buildName": values[3],
        "cost": +$('.costform').val(),
        "maxCount": +$('.countform').val()
    });
    console.log(buildDto);
    $.ajax({
        url: 'https://localhost:44357/api/General/SetBuild',
        type: 'POST',
        data: buildDto,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        processData: false,
    }).done((json) => {
        console.log(json);
    }).fail((er) => {
        console.log(er);
    })
})

$('.selectform').on('change', function () {
    var values = $(this).val().split(',');
    console.log(values);
    $('.costform').val(values[0]);
    $('.countform').val(values[1]);

})