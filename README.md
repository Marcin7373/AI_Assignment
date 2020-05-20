# Dynamic Cowboy Bebop Scene Recreation 

The scene is a dogfight between Spike in his SwordFish (red jet) and 2 attacking jets.
The scene will involve seeking, pathfollowing, pursuing and other AI methods to dynamically 
simulate the fight. The swordfish will mainly follow a path trying to avoid rockets and obstacles
while the attacking jets will pursue and fire rockets and other projectiles. An important aspect will be the many
different camera perspectives that will be used from following a target from a stationary point
to being attached to the top or the wing of either of the jets and to following different targets. 
These camera angles will require basic seek and pursue algorithms while controlling what its looking at. 

### Original
[![VideoRef](https://img.youtube.com/vi/N-nRnddi7Q8/0.jpg)](https://www.youtube.com/watch?v=N-nRnddi7Q8)

### Recreation
[![VideoRef](https://img.youtube.com/vi/iBngqs_3u_4/0.jpg)](https://www.youtube.com/watch?v=iBngqs_3u_4)

## Story Board

The scene starts with the 2 attacking jets chasing the Swordfish as its following a path to get under the pipe to try and lose the chasers. The attackiing jets using a manager appoint a leader who pursues and the rest follow in formation. The leader fires bullets and homing rockets and is reassigned by the manager when dead.
Each has on rocket which when used splits into a few. Each also uses a state machine from offset pursuing to pursuing where they can fire to dying if they are hit.

![ref5](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref5.PNG?raw=true)
![fin1](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/fin1.PNG?raw=true)  

The most complex aspect was the camera which needed to know where, when and for how long to look.
Multiple cameras were set up to switch between as well as camera targets for the mobile camera to follow.
This was done in the manager which controlled everything in the scene. It managed the camera with flags where 
certain where kept track with timers done by coroutines and one general timer locking the camera with a delay preventing too much switching. Dying and firing rockets were prioritzed. The place where teh first jet crashes is below the pipe like in the video where the 
Swordfish releases a flashbang like distraction.

![ref9](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref9.PNG?raw=true)
![fin2](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/fin2.PNG?raw=true) 

This is where the leader is changed with the fight going towards the wall where the second jetfires everying it has but can turn fast enough and crashes.

![ref7](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref7.PNG?raw=true)
![ref15](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref15.PNG?raw=true)
![fin3](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/fin3.PNG?raw=true) 

Particle effects and trails were also used for trails with the explosions for jets crashing being particularly difficult as they hit something they go into a dying state but the craft is still intact. The Boid component is turned off and gravity on a rigidbody is turned on to make it fall and crash causing another explosion. Baccano soundtrack was used which has a similar style to the one from the video making it sound like its coming from the Swordfish's cockpit. The hardest part was making the Swordfish win by the attacking jets crashing were they sometimes avoided death with the Swordfish needing to follow a path because fleeing randomly wouldnt get the killed. Following a pat gave the most relaible results in replicating the scene.

