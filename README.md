# Redirected-walking-RDW-API
This is redirected walking API for our lab.

Because locomotion in virtual reality affects a user’s experience, various researches have studied locomotion techniques to provide a realistic experience. Among the locomotion techniques, actual walking induces higher immersion and natural and effective exploration for users. ReDirected Walking (RDW) has been studied as a technique that can overcome the difference between virtual and real space to explore a virtual environment through real walking. In particular, much research has been done on finely manipulating the user’s scene in a range that the user is unaware of.

# Requirement
+ Unity 2019.4.10+
+ Unity [ML Agents](https://github.com/Unity-Technologies/ml-agents) package 1.6+

# How to use
1. Unity project 를 생성한 뒤에, project 폴더 하위에 있는 Assets 폴더에 위의 파일들을 추가해준다.
2. **_Scenes_** -> **_RedirectedSpaceSimulation_** scene 을 실행한다.
3. scene 상에 있는 **_RDSSimulation_** 객체에 부착되어 있는 **_RDWSimulationManager_** 의 값들을 적절하게 조절해준다.
4. 해당 scene을 실행한다.

# RDWSimulationManager Options
* **Simulation Setting**
  + Use Debug Mode: 각 object들의 외곽선이나 user의 경로 등을 시각화할지 결정
* **Prefab Setting**: 실험에 사용될 Prefab들을 지정
* **(Real/Virutal) Space Setting**
  + Use Predefinded Space: 미리 정의된 Space를 사용할지 결정
  + Name: Space 객체의 이름
  + Predefined Space: 사용할 Space 객체
  + Position: Space 객체의 위치
  + Rotation: Space 객체의 회전 값
* **Unit Setting**
  + Redirect Type: 적용할 Redirection algorithm 종류
  + Reset Type: 적용할 Reset algorithm 종류
  + Episode Type: 사용하고자 하는 Episode 종류
  + Episode File Name: Pre-define Episode 사용시, 정의된 episode 파일
  + Use Random Start: 임의의 위치에서 unit을 시작할지 결정
  + User Prefab: 실험에 사용될 user 객체
  + User Start Rotation: user의 시작 회전값
  + Real Start Position: 실제 user의 시작 위치
  + Virutal Start Position: 가상 user의 시작 위치
  + Translation Speed: user의 이동 속도
  + Rotation Speed: user의 회전 속도

이 외의 옵션들은 아직 개발 중이며, 해당 옵션을 조절할 시 정상적으로 작동되지 않을 가능성이 있으니 주의.

# Class hierachy
