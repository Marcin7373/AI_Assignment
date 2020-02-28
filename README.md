# Dynamic Cowboy Bebop scene recreation 

The scene is a dogfight between Spike in his SwordFish (red jet) and 2 attacking jets.
The scene will involve seeking, pathfollowing, pursuing and other AI methods to dynamically 
simulate the fight. The swordfish will mainly follow a path trying to avoid rockets and obstacles
while the attacking jets will pursue and fire rockets and other projectiles. An important aspect will be the many
different camera perspectives that will be used from following a target from a stationary point
to being attached to the top or the wing of either of the jets, to following from different offsets 
by having the camera fly in formation with the target while also avoiding the terrain.
These camera angles will require basic seek and pursue algorithms but also ones like flying in formation and independently 
controlling what its looking at. 

[![VideoRef](https://img.youtube.com/vi/N-nRnddi7Q8/0.jpg)](https://www.youtube.com/watch?v=N-nRnddi7Q8)

## StoryBoard

![ref1](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref1.PNG?raw=true) 

The scene will start by having the Swordfish following a path while the camera flies in formation.

![ref2](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref4.PNG?raw=true) 

The camera will then switch to be on top of an attacker jet firing rockets with trails at the Swordfish.

![ref3](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref5.PNG?raw=true) 

The camera will then move to a fixed point far away following the action showing the full picture of what is happening
as the rockets follow the Swordfish they will break up into shrapnel when they get close enough as
the Swordfish scans behind it and dodges them while following a path.

![ref4](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref7.PNG?raw=true)  

Another interesting angle will be used by placing the camera following the attacker jet in position
while looking at the SwordFish as the attacker fires a gun allowing the bullets to be followed from a slight angle
from the attacker jets perspective.

![ref5](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref9.PNG?raw=true)

The SwordFish will then try losing them by following a path around the pipe shown being approached in the last angle.
It will drop blinding projectiles making one attacker jet crash while the other detaches from the formation and follows on top out of sight.

![ref6](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref15.PNG?raw=true)

The SwordFish then flies towards a giant wall avoiding gun fire and more rockets this time shown by having the camera 
following the SwordFish in position but looking at the rockets as they fly out of the attacker jet and flipping around watching them fly past towards the SwordFish.

![ref7](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref16.PNG?raw=true) 

Then switching to having the camera fly in formation with the rocket while looking at the SwordFish.

A second scene in an area with water, a bridge and a ship as an onstacle for the attacking jet to crash into.
The fight will end with the SwordFish firing at the water before the bridge blinding the second attacker jet for a moment and flying into an obstacle and exploding.
