# Form Submission Application

---

## Windows Desktop App

### Overview

The Windows Desktop App allows users to create new submissions and view existing submissions. It includes features such as:

- **Create New Submission**: Enter details such as Name, Email, Phone Number, GitHub link, and Stopwatch time. The Stopwatch can be paused and resumed.
- **View Submissions**: Navigate through submitted forms using Next and Previous buttons.
- **Keyboard Shortcuts**: Efficiently navigate and submit forms using keyboard shortcuts (e.g., `Ctrl + S` to submit).

### Screenshots

1. **Create New Submission Form**
   ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/ebd832a6-1e04-44ca-980f-340f3094168c)


2. **View Submissions Form**
   ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/a814c9d0-36f6-462e-8ad7-04ad6865ec47)


### Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/form-submission.git
   cd form-submission
 
2. **Open and Build the Project in Visual Studio**
   ```bash
   - Open the solution file (`FormSubmission.sln`) in Visual Studio.
   - Build the solution (`Ctrl + Shift + B`).


3. **Run the Application**

   - Start the application by pressing `F5` or clicking `Start` in Visual Studio.

4. **Usage**

   - Use the application to create new submissions and navigate through existing submissions.
   - Ensure you have an active internet connection to submit and retrieve data from the backend server.


## Express Server (Backend)

### Overview

The Express server handles API requests for storing and retrieving form submissions. It includes endpoints for:

- **/ping**: GET request to check server status.
- **/submit**: POST request to save form submissions.
- **/read**: GET request with query parameter `index` to fetch a submission by index.

### Requirements

- Node.js
- TypeScript
- Express

### Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone [https://github.com/Rohit1170/FormSubmission.git](https://github.com/Rohit1170/FormSubmission.git)
   cd FormSubmission
   ```

2. **Install Dependencies**
   ```bash
   npm install
   ```

3. **Build and Run the Server**

   - Build TypeScript files:

     ```bash
     npx tsc
     ```

   - Start the server:

     ```bash
     npm run dev
     ```

4. **Database**

   - Submissions are stored in `data.json` file in JSON format.

### Endpoints

- **Ping**: GET request at `/ping` to check server status.
- **Submit**: POST request at `/submit` to save form submissions.
- **Read**: GET request at `/read?index=<index>` to fetch a submission by index.

### Screenshots

- ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/57041735-4c7d-429c-b7ed-cb7d05796592)
- ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/3fa2b290-b170-43a8-8817-f2d24a29aa1c)
- ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/b506b41b-df19-4c97-b416-c1e49a95b77a)
- ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/f0f52c12-55f2-4476-a29d-14cbdea3964c)
- ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/1e4a4378-5451-40eb-916b-bfc1739e1256)
- ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/c5732140-d791-48b3-9f4f-dc2593a9dc78)
- ![image](https://github.com/Rohit1170/FormSubmission/assets/87237888/7865b265-55fc-4c14-a52f-4117532b254b)


---



## Author

- Your Name
- GitHub: [Your GitHub Profile](https://github.com/Rohit1170)
```
