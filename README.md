# WW_Test_Part2
Evaluate the advantages and disadvantages
1, Advantages:
- Easy to understand, Beginner friendly, Debugging friendly
- Already used Static and Dynamic Batching to reduce draw calls
- Used State Machine to managing the game flow
2, Disadvantages:
- Dont have a pooling object system
- Using Resources.Load, Instantiate, Destroy too much in runtime (before fix) so it would be hard to scale bigger level
- The Inheritance in Class Item is tangled, should have more define properties
- Some Enum should be put in separated class
- Using too much GetComponent, FindObjectOfType,...
3, Suggestion:
- Should try drag prefabs into scene instead of calling Resources.Load
- Use more Scriptable Object and organize it into a SO folder
- Using Interface for better scale
- Utilize object pooling
- Use Sprite Atlas for texture
- Put widely used enum in separated class
- For some file that contains Config Data line Constant.cs, you can try put in in txt file and upload, download through Cdn, so some bug can be fix by upload and redownload cdn files. So you dont have to rebuild project. 
