# Redirected-walking-RDW-API
본 프로젝트는 컴퓨터 그래픽스 연구실 소속으로, 손쉽게 Redirected walking을 구현해서 simulation 할 수 있고 공유할 수 있는 API를 만들기 위해 진행된 것이다. 해당 프로젝트의 현재 버전은 시연은 가능하나 완벽히 배포 가능한 상태는 아니며 연구실 구성원들의 QA를 통해서 개발 중이다. 현재는 구성원마다 독자적으로 이것을 확장 및 수정하여 사용하고 있다.

Redirected walking (RDW)는 사용자가 좁은 실제 공간과 충돌하지 않으면서 넓은 가상 공간을 실제로 걸어서 탐험할 수 있도록 사용자 동작을 조작하는 기법을 말한다. 구체적으로 RDW는 사용자가 해당 기법에 적용되었는지를 인식 했냐에 따라서 subtle 방식 (Redirection) 과 overt 방식 (Reset)으로 나뉘며, 각 기법마다 서로 장단점이 존재하기 때문에 최근까지 연구된 대부분의 이론에서는 두 기법을 섞어서 사용하고 있다. 

RDW API는 Unity를 통해서 가상 현실 보행 기법인 Redirected walking을 Unity3D 위에서 보다 더 쉽게 simulation 하기 위해 만들어졌다. 해당 API의 특징은 다음과 같다.
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
1. **RDWSimulationManager**는 Unity Scene 상에서 Simulation에 필요한 여러 옵션들을 입력 받는다.
2. **RDWSimulationManager**는 내부적으로 여러개의 **Setting** 들을 포함하고 있으며, Setting은 입력 받은 값을 통해서 알맞은 Builder를 호출하여 Simulation에 필요한 Object들을 (RedirectedUnit, Space2D 등) 생성하여 반환한다.
3. **RedirectedUnit**는 Simulation을 진행을 위한 내부적인 Manager로 볼 수 있으며 실제 공간, 가상 공간, 실제 사용자, 그리고 가상 사용자에 대한 정보를 포함하고 Simulation의 1 step을 진행시키며 State 패턴을 통해서 Simulation이 끝났는지를 매번 검사한다.
4. Simulation에 필요한 모든 객체는 위에서 바라본 것을 기준으로 2차원 정보인 **Object2D** 형태로 저장된다. 이것은 위에서 바라본 2차원 정보만으로도 가상 공간 보행 simulation이 동작할 수 있기 때문이다.
5. **Object2D**는 Adapter 패턴을 응용해서 Unity에서 제공하는 각 객체의 3차원 transform 변수 중에서 두개의 차원 값을 적절하게 선택해서 반환하거나 관련된 함수를 내부적으로 호출하는 방식으로 구현되었다.
6. **Resetter**, **Redirector**, **SimulationController**는 각각 Simulation에 실제 공간 경계에 부딪혔을 때 어떤 식으로 대응할 지, 가상 공간 사용자를 어떤 식으로 유도할지, 사용자가 어떤 방식으로 이동하는지를 결정한다. 

자세한 구조는 [다음과 같다](/Class%20Diagram%20for%20RDW%20API.pdf).
