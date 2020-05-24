# Dynamic Cowboy Bebop Scene Recreation 

The scene is a dogfight between Spike in his SwordFish (red jet) and 2 attacking jets.
The scene will involve seeking, pathfollowing, pursuing and other AI methods to dynamically 
simulate the fight. The swordfish will mainly follow a path trying to avoid rockets and obstacles
while the attacking jets will pursue and fire rockets and other projectiles. An important aspect will be the many
different camera perspectives that will be used from following a target from a stationary point
to being attached to the top or the wing of either of the jets and to following different targets. 
These camera angles will require basic seek and pursue algorithms while controlling what its looking at and will be used to tell the story. 

### Instructions

It's all autonomous, the scene plays itself, the camera is controlled dynamically. (Sometimes if a prefab is selected or a big object is displayed in the inspector it may drop frames or incase of prefab e.g. rocket the rocket might drop with the seek target not being set = simply run again)

### Original
[![VideoRef](https://img.youtube.com/vi/N-nRnddi7Q8/0.jpg)](https://www.youtube.com/watch?v=N-nRnddi7Q8)

### Recreation
(Dropping some frames at the start because of OBS, should be smoother when run)
[![VideoRef](https://img.youtube.com/vi/iBngqs_3u_4/0.jpg)](https://www.youtube.com/watch?v=iBngqs_3u_4)

## Story Board

The scene starts with the 2 attacking jets chasing the Swordfish as its following a path to get under the pipe to try and lose the chasers. The attackiing jets using a manager appoint a leader who pursues and the rest follow in formation with offset pursue. The leader fires bullets and homing rockets and is reassigned by the manager when dead.
Each has one rocket which when used splits into a few more all seeking the target. Each also uses a state machine which switches from offset pursuing to pursuing where they can fire at the target to dying if they are hit where the model is simply left up to gravity to crash and is the destroyed. All jets also use obstacle avoidance.

![ref5](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref5.PNG?raw=true)
![fin1](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/fin1.PNG?raw=true)  

The most complex aspect was the camera switching which needed to know where, when and for how long to look.
Multiple cameras were set up to switch between, as well as camera targets for the mobile camera to follow with smoothing. The mobile camera has a few way in which its used like being given a new target to follow with the camera follow script or its position being changed before switching to it making it very dynamic. This was done in the manager which controlled everything in the scene. It managed the cameras with flags where certain variables where kept track of with timers done by coroutines where certain actions like firing bullets could be set to be shown for a max period of time before allowing switching. And one general timer locking the camera with a delay preventing too much switching to not confuse the viewer. Dying and firing rockets were prioritzed as they are rear they can bypass the timed delay before switching to not miss them. The place where the first jet crashes is below the pipe like in the video where the Swordfish releases a flashbang like distraction which is shown with a preset camera target where the camera will point at the crash wherever it happened from a distance showing full context on how it happened. All switching is done dynamically as needed so even if the events are similar, some things the camera chooses to show may be different each time its run. The flashbang is 2 partcle effects which are released a certain distance behind the swordfish in the direction of the leader jet making the "cloud" fly at it.

![ref9](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref9.PNG?raw=true)
![fin2](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/fin2.PNG?raw=true) 

This is where the leader is changed with the fight going towards the wall where the second jetfires everying it has but can't turn fast enough and crashes too with the camera from the same position as the last crash is pointed dynamically at the crash position. The bullets are fired by calculating the angle from the forward vector only firing if its within a certain angle with the rockets also looking the distance as the rockets are given a high speed and need room to turn. Each projectile is given a kill script which kills it on collision, set lifetime and has a delay allowing for a delay after collision for a bounce effect specificslly for bullets.

![ref7](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref7.PNG?raw=true)
![ref15](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/ref15.PNG?raw=true)
![fin3](https://github.com/Marcin7373/AI_Assignment/blob/master/StoryBoard/fin3.PNG?raw=true) 

Particle effects and trails were also used for trails with the explosions for jets. Crashing being particularly difficult as the jet hit something they go into a dying state with the craft being intact. The Boid component is turned off and gravity on a rigidbody is turned on to make it fall and crash causing another explosion. Baccano soundtrack was used which has a similar style to the one from the video making it sound like its coming from the Swordfish's cockpit. The hardest part was making the Swordfish win by the attacking jets crashing were they sometimes avoided death with the Swordfish needing to follow a path because fleeing randomly wouldnt get them killed. Following a path gave the most relaible results in replicating the scene. Im most proud of the camera and how dynamic the scene looks because of it and the particle effects making the viewer feel like they're part of the action.

Scripts used = Boid, FollowPath, ObstacleAvoidance, Path, OffsetPursue, Pursue, Seek, StateMachine, SteeringBehaviour.   
Scripts I made = AttackJet, Bullet, CameraFollow, Manager, ProjectileKill, RocketClone, SwordFish.  
Assets used = Terrain, AttackJet and Swordfish models, skybox, metal textures and the song.  
Assets made = Wall, Pipe, all particle systems and materials for them.  
