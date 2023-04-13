
build(commandCenter,1000,1).
build(power,1000,1).
build(barracks,1000,1).
build(defences,1000,1).
build(mine,1000,1).
build(airport,1000,1).
build(warFactory,1000,1).
build(strategyCenter,1000,1).
build(hospital,1000,1).
build(radar,1000,1).
build(nuclearPower,1000,1).
build(superWeapon,1000,1).




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
need(nuclearPower,[strategyCenter]).



isMember(X,[X|T]).
isMember(X,[H|T]):- isMember(X,T).

isNotMember(X,[]).
isNotMember(X,[H|T]):- H \== X, isNotMember(X,T).


getAllBuildings(Result):- findall(H, build(H,_,_),Result).

whatNeed(Building,NeededBuilding):- need(Building,NeededBuilding).


isMoneyEnough(Building,MyMoney):- build(Building,Cost,_) , Cost =< MyMoney.

isNotMax(Building,Count):- build(Building,_,Max) , Count < Max.



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

isBuildingsExist(Building,MyBuildings) :- need(Building,BuildingsList),isBuildingsExist(Building,MyBuildings,BuildingsList).

isBuildingsExist(_,_,[]).

isBuildingsExist(Building,MyBuildings,[H|T]) :- 
isMember(H,MyBuildings) ,  
isBuildingsExist(Building,MyBuildings,T).

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

isCanBuild(Building,MyBuildings,MyMoney,Count,Needed) :- not(isBuildingsExist(Building,MyBuildings)) , need(Building,Needed).
isCanBuild(Building,MyBuildings,MyMoney,Count,money) :- not(isMoneyEnough(Building,MyMoney)).
isCanBuild(Building,MyBuildings,MyMoney,Count,max_count) :- not(isNotMax(Building,Count)).

isCanBuild(Building,MyBuildings,MyMoney,Count,yes).

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

whatCanBuild(MyBuildings,MyMoney,CountList , ResultList) :- 
getAllBuildings(AllBuildings), 
whatCanBuild(MyBuildings,AllBuildings,MyMoney,CountList , ResultList).

whatCanBuild(_,[],_,[],[]).

whatCanBuild(MyBuildings,[H1|Buildings],MyMoney,[H2|Counts] , Result) :-  
isCanBuild(H1,MyBuildings,MyMoney,H2,R), R \== yes, 
whatCanBuild(MyBuildings,Buildings,MyMoney,Counts ,Result).


whatCanBuild(MyBuildings,[H1|Buildings],MyMoney,[H2|Counts] , [H1|Result]) :-  
whatCanBuild(MyBuildings,Buildings,MyMoney,Counts ,Result).

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

isNeeded(H,Building):- need(H,L),isMember(Building,L).

whoNeedThis(Building,Result) :- findall(H,isNeeded(H,Building),Result).