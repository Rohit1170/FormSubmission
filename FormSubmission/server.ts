import express, { Request, Response } from 'express';
import fs from 'fs';
import path from 'path';

const app = express();
const port = 3000;

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

const dataFilePath = path.join(__dirname, 'data.json');

interface Submission {
    name: string;
    email: string;
    phone: string;
    github_link: string;
    stopwatch_time: string;
}

function readData(): Submission[] {
    try {
        const data = fs.readFileSync(dataFilePath, 'utf8');
        return JSON.parse(data) as Submission[];
    } catch (err) {
        console.error('Error reading data file:', err);
        return [];
    }
}

function writeData(data: Submission[]): void {
    try {
        fs.writeFileSync(dataFilePath, JSON.stringify(data, null, 2), 'utf8');
    } catch (err) {
        console.error('Error writing data to file:', err);
    }
}

app.get('/total', (req: Request, res: Response) => {
    const submissions = readData();
    res.json({ count: submissions.length });
});

app.get('/ping', (req: Request, res: Response) => {
    res.send('True');
});

app.post('/submit', (req: Request, res: Response) => {
    const submission: Submission = req.body;
    const submissions = readData();
    submissions.push(submission);
    writeData(submissions);
    res.send('Submission successful!');
});

app.post('/update', (req: Request, res: Response) => {
    const index = parseInt(req.query.index as string, 10);
    const updatedSubmission: Submission = req.body;
    const submissions = readData();

    if (index >= 0 && index < submissions.length) {
        submissions[index] = updatedSubmission;
        writeData(submissions);
        res.send('Update successful!');
    } else {
        res.status(404).send('Submission not found');
    }
});

app.delete('/delete', (req: Request, res: Response) => {
    const index = parseInt(req.query.index as string, 10);
    const submissions = readData();

    if (index >= 0 && index < submissions.length) {
        submissions.splice(index, 1);
        writeData(submissions);
        res.send('Deletion successful!');
    } else {
        res.status(404).send('Submission not found');
    }
});

app.get('/read', (req: Request, res: Response) => {
    const index = parseInt(req.query.index as string, 10);
    const submissions = readData();

    if (isNaN(index)) {
        res.json(submissions); // Return all submissions if no index is provided
    } else if (index >= 0 && index < submissions.length) {
        res.json(submissions[index]); // Return the specific submission
    } else {
        res.status(404).send('Submission not found');
    }
});

app.listen(port, () => {
    console.log(`Server listening on port ${port}`);
});
