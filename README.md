# Redirected-walking-RDW-API
Redirected walking는 사용자가 좁은 실제 공간과 충돌하지 않으면서 넓은 가상 공간을 실제로 걸어서 탐험할 수 있도록 사용자 동작을 조작하는 기법을 말한다.
RDW API는 Unity를 통해서 가상 현실 보행 기법인 Redirected walking을 보다 더 쉽게 simulation 하기 위해 만들어졌다. 해당 API의 특징은 다음과 같다.
* 가상 현실 보행 분야에서 많이 사용되고 있는 Steer-to-Center (S2C) 를 탑재
* 자신이 제안한 새로운 Redirection 혹은 Reset algorithm을 쉽게 추가 및 교체
* Single User가 아닌 2명 이상의 Multi user를 지원
* Simulation 과정 시각화
* 다양한 형태의 가상 환경에서의 Simulation 가능 (장애물 존재 등)
* 그 외 python의 시각화 및 통계 tool과 연계 및 ML-agents를 통한 강화 학습 기반 Redirection algorithm 추가가 가능하도록 구현중

<p align="center">
  <img 
    width="80%"
    src="/teaser_video.gif"
  >
</p>

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

이 외의 옵션들은 개발 중이며, 해당 옵션을 조절할 시 정상적으로 작동되지 않을 가능성이 있으니 주의.

# Class Diagram
[See here](/Class%20Diagram%20for%20RDW%20API.pdf)
