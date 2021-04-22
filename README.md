# Hospital-Simulation
Goal oriented action planning is an artificial intelligence system for agents that allows them to plan a
sequence of actions to satisfy a particular goal.
The particular sequence of actions depends not only on the goal but also on the current state of the
world and the agent.
This means that if the same goal is supplied for different agents or world states, you can get a
completely different sequence of actions.
,which makes the AI more dynamic and realistic.

Reference(https://gamedevelopment.tutsplus.com/tutorials/goal-oriented-action-planning-for-a-smarter-
ai--cms-20793)

In This Project , I created a Hospital Simulation Based On Some Goals And Some Set Of Action In Goal.
No node is connected To each Other, Refering to My Project Their Are set of actions like
GoToHospital,Register,GoToWaitingRoom,GetTreated ,PickUpPatient , But None of this Actions Are
connected , AI Will Choose Every Action based on pre Conditions If Pre Condition Is satisfied then AI
Will Go For Next Action And So on .Like In Order To Get Treated(Our Goal As A Patient) ,First WE
Should Wait for Nurse In order to Get Treated By Nurse We have To register In order To Register We
Have to Go To Hospital;
What Patient Will do:
1 ) go to hospital
2) register himself
3) wait in waiting room
4) when nurse pick him up go to cubicle
5) do checkups
6) Go home

what nurse will do
1) check is there any patient in waiting room
2 ) is there any cubicle available
3) take him to cubicle
5 ) Rest when exhausted
4) start from step 1

Patient Goal : - Wait For Nurse,Get Treated ,Go Home
Nurse Goal :- Treat Patient , Rest

SO AI Will Create A Plan Something Like This

Goal :- GetTreated ;

(Patient AI)

Pre Condition Post Effects

NoPLAN

(NURSE AI)

NO Plan

(Patient AI Got Plan , Nurse Still Have No Plan)

GoToHospital None HasArrived(Hospital)
Register HasArrived hasRegistered
GoToWaitingRoom hasRegistered IsWaiting(Waiting For Nurse)

(Nurse Got a Plan)

TreatPatient IsWaiting && Cubicle Are Free? TakeHimToCubicle

(Patient Got a Plan)

GetTreatment GetTreated isTreated

(Patient Goal 1 Satisfied)
(Patient Goal 2 Is started)

GotoHome isTreated GoHOME(Detroy this Gameobject)

(Nurse Ai Got PLAN)

TreatPatient I sWaiting && Cubicle Are Free? TakeHimToCubicle(After Random Time Set After
effect Exhausetd)
Exhauseted Exhausted Rest

(Nurse Ai Got Plan)
(Repeat Last 2 step until there is a plan)

Yet To Build:-
Emergency Ward
Toilet
Doctor CheckUp
