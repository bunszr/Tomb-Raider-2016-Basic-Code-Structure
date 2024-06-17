
## Introduction
You can think of the project as the basic code structure of TombRaider 2016. I started developing it inspired by that game. If you’re not familiar with the game, I highly recommend checking it out to understand this project better.

The most challenging thing when I started learning software and game development was applying what I learned to the real world. It’s relatively easy to understand concepts with 3-5 classes. but when it comes to real-world implementation,, I get stuck. What makes this project different from others is the focus on understanding software engineering concepts such as MVC architecture, SOLID principles, DI etc. with real and complex scenarios. Because well understaning of many concepts in software requires big project.

Another important aspect is gradually presenting new features to the player within the game. Tomb Raider handles this very well. One of my major goals in developing this project is to test my architecture skills and manage complex project/game logic and behaviors.

I also touched on some points where I violated MVC or had bad code implementation in youtube video. Youtube video consist these parts: Intruduction, Area, Campsite, Weapon, Enemy, Player, Save System, Input, MVC, Violating MVC, SOLID, DI, Power of UniRx, Working with Non-Monobehaviour classes, ...Ability(Testability, Maintainability...) and Final Thoughts.

Youtube video link: https://www.youtube.com/watch?v=YoijL8v2vGo 

## **If you review the project and watch the YouTube video, you can learn the following;**

- **MVC (Model-View-Controller)**
- **SOLID principles**
- **The beauty of working with Non-Monobehaviour classes**
- **Working with internal Update Manager**
- **Testability, Maintainability, Flexibility, Reusability, Scalability, Readability**
- **Using Dependency injection**
- **Power of UniRx**

## **Working with Non-Monobehaviour Classes**
I had started to learn sofware with console and desktop applications using Visial Studio. It was frequently using "new" keyword. When I began to learn unity, it does not use "new" keyword. it is used monobehaviour and its lifecycle methods. I had struggled to implement things that I learned from console and desktop applications essipecialy creating a new class. Almost every tutorial I watched is used mononbehaivour class instead of pure c# class. 

However I realized that there are many benefits of using pure c# class. As I mentioned, you will notice the beauty of working with Non-Monobehaviour classes in project. They bring several advantages, such as improved readability and easier management of behaviors.

# **MVC (Model-View-Controller)**

I have always been curious and envious of the title of "principal architect" because I struggle to write maintainable code and manage complex behaviors, as well as present new features gradually to the player. I often got stuck somewhere later in the project. If we research about "principal architect", we comeacross concepst of software arhitecture (MVC, Scriptable Object arhitecture etc.). Initially, when I read or watched content about MVC, I thought it was nonsense. I believed I could achieve the same results with just a few lines of code, without needing so many classes and so much code. but then I realized that it has many benefits and beauty.

So it need to be large project to understand MVC. One of major goal of project is to explain MVC. I also want to share a few pros of MVC, but keep in mind these pros are most relevant when working with large projects. If you are working small project then these pros might turn into cons.

### Pros:
- **We know what to look for and where to look for it.** MVC provides a clear structure, making it easier to locate and manage code.
- **It is a guideline to understand project structure**
- **Ability to divide labor.** Some developers can work on the view while others work on the controller
- **Reduce conflicts and development process.**

# **Design Patterns which is used in project**
- **Command Pattern :** Area and campsite
- **Chain Of Responsibily :** Health and armor
- **State Machine :** Weapon reloading and player
- **Observer :** Campsite panel activate and deactivate
- **Behaviour Tree :** Enemy behaviours
- **Strategy :** In many places

## **Known Issue**
- Many campsite commands depend on singleton class of GameDataScriptable. This is inappropriate because there might be another data to manipulate same behaviour.
- UpdateManager is singleton class. But we want to use update manager with unscaled delta time. it need to be improved such a stutions.
- The main purpose of project is to understand and improve my coding skill therefore some mechanics does not work properly every scenerio
- As I mentioned in the video section about violating MVC, I am intentionally or unintentionally violating MVC in the project.
- Since there are some repetitive tasks in the Behavior Tree (BHT), it makes sense to turn it into a ScriptableObject BHT. However, this would be more appropriate as the project grows.
- I could give more importance about encapsulation.
- It should be animation parameters vector instead of float in campsite. It is provide us more animation capability. It also can be reset with TransformRecovery class.

## **Final Toughts**
- The most important thing that I learned and encountered while doing research is "no one rule to rule them all". There is no single thing to solve our problems, everything can change according to our situation. Using MVC pattern, dependency injection framework or whether adhering solid principle, depends on resources, time, our team, and so on. It is important and difficult point is that we choose the best option for ourselves.  
- I always try to read zenject documentation to understand the IoC container and how it makes my life easier. DI freamwork is already popular now. I think If we putt effort into using them everywhere, complexsity is getting incereases and making it hard to understand, trace, and read our code. It is unnecessary to exaggerate very much because of inspector and manual injection. 
- The most important things that i understand MVC and SOLID is "divide and conquer" or "separate behaviours to small parts and merge them later however you want"
- It is beatiful to see what is going on in project with advenced log message in editor or after build If it is added logger framework such as ZLogger. Actually i avoided to add and learn ZLoggger to the project due to project exhaust me.
- I wanted to continue project to find solutions for problems that will come up later. As the project gets bigger, it will be a challenge to manage the interaction of classes and game objects.
- It is wrong to learn IoC freamwork and apply it everywhere or to learn Scriptable Object architecture and apply it everywhere. Every approch have a pros and cons. The solution can be changed depends on our situation
- We should not create abstractions early unless we are experienced developers
- It might make sense to put everything related to the campsite or area etc. under a separate folder. This will create a better folder structure

## **I found usefull link etc. while developing projects**
- https://www.sebaslab.com/ioc-container-unity-part-2/ - Also there are many article that i'd recomend you to take a look
- https://forum.unity.com/threads/singletons-service-locators-dependency-injections-oh-my.1413726/

## Assets In Project

### Added to project
- UniRx : https://github.com/neuecc/UniRx
- Zenject : https://github.com/modesttree/Zenject
- UnityHFSM (Hierarchical Finite State Machine) : https://github.com/Inspiaaa/UnityHFSM
- Lean Pool : https://assetstore.unity.com/packages/tools/utilities/lean-pool-35666
- DOTween : https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676
- Transform Reset (Editor tool to reset transform(pos, rot, scale) with button) : https://assetstore.unity.com/packages/tools/utilities/transform-reset-31313
- Invector Third Person Controller - Basic Locomotion FREE : https://assetstore.unity.com/packages/tools/game-toolkits/third-person-controller-basic-locomotion-free-82048
- Low Poly Guns : https://assetstore.unity.com/packages/3d/props/guns/guns-pack-low-poly-guns-collection-192553
- Homeless - Inventory item sprites : https://assetstore.unity.com/packages/2d/gui/icons/2d-items-set-handpainted-210729
- Hierarchy 2 : https://github.com/truongnguyentungduy/hierarchy-2
- InspectPlus : https://github.com/yasirkula/UnityInspectPlus
- RunTime Gizmos : https://github.com/popcron/gizmos
- StoringDataJsonUnity-master : https://github.com/MichelleFuchs/StoringDataJsonUnity
- Unity-Folder-Icons : https://github.com/WooshiiDev/Unity-Folder-Icons
- Unity-UI-Rounded-Corners : https://github.com/kirevdokimov/Unity-UI-Rounded-Corners

### Added to the project but not in the project
- Behaviour Designer : https://assetstore.unity.com/packages/tools/visual-scripting/behavior-designer-behavior-trees-for-everyone-15277
- Dreamteck Spline : https://assetstore.unity.com/packages/tools/utilities/dreamteck-splines-61926#content
- Odin Inspector : https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041

### Things I want to do
- Unit testing
- Integrate Logger framework

### Game Visuals
<img src="Assets/Game Views/In Game 1.png" >
<img src="Assets/Game Views/In Game 2.png" >
<img src="Assets/Game Views/In Game 3.png" >
<img src="Assets/Game Views/In Game 4.png" >

### Behaviour Tree Visuals
<img src="Assets/Game Views/Enemy Pistol.png" >
<img src="Assets/Game Views/Enemy Riffle.png" >


