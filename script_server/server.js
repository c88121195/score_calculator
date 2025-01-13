const express = require("express");
const { exec } = require("child_process");
const app = express();
const port = 3000;

app.use(express.json());

app.post("/switchScene", (req, res) => {
    const { sceneName } = req.body;

    exec(`python switch_scene.py ${sceneName}`, (error, stdout, stderr) => {
        if (error) {
            res.status(500).send(`Error switching scene: ${error.message}`);
            return;
        }
        res.status(200).send(`Scene switched to ${sceneName}`);
    });
});

app.listen(port, () => {
    console.log(`Listening on port ${port}`);
});