# VGDC Unity MLAgents Workshop

## Step 1: Unity + Python setup

### Ensure a recent version of Unity is installed
- Download Unity hub or the most recent version of Unity [here](https://unity3d.com/get-unity/download) 

### Create a folder named "MLAgentsWorkshop" Somewhere on your PC
- This step is not mandatory, however, it will help you keep track of the workshop files. 
- For this workshop, we assume that you have created this folder.

### Download Python version **3.7.9**
    
- Create a folder within our MLAgentsWorkshop folder named "Python"
    
**For Windows users:** 
- Navigate to https://www.python.org/downloads/windows/
- Find Python **3.7.9**
- Select "Windows x86-64 executable installer"
- Store your Python download in the folder labelled Python we created above.
**For Mac users:**
-  You should already have Python 3.7.9 installed, making this step unnecessary. 

### Set up a Virtual Environment:

- Open up either command prompt, or terminal depending on your respective OS
- Change directories to the recently created MLAgentsWorkshop folder
    - `` cd /path/to/MLAgentsWorkshop/ ``

**For Windows users:**
- Install the virtual environment tool
    `` pip3 install --user virtualenv ``
- Create and activate the virtual environment
    ```
    virtualenv --python=D:\MLAgentsWorkshop\Python\python.exe cuberunnerenvironment

    cuberunnerenvironment\Scripts\activate.bat
    ```
- Install the mlagents Python package
    - ``pip3 install mlagents``

**For Mac users:**
- Install the virtual environment tool
    `` pip3 install virtualenv ``

- Create and activate the virtual environment
    ```
    python3.7 -m venv cuberunnerenvironment
    
    source cuberunnerenvironment/bin/activate
    ```
- Install the mlagents Python package
    - ``pip3 install mlagents``

### Download the GitHub Repo
- Create a new folder within the MLAgentsWorkshop folder named CubeRunnerAI
- Download this Repo as a Zip file, and extract it's contents into the CubeRunnerAI folder 