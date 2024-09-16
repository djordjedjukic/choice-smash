# Choice smash
Choice smash is an implementation of the classic “Rock, Paper, Scissors, Lizard, Spock” game, designed for interview purposes.

I did as much as possible in the time frame we agreed I would deliver this task.
I had some doubts regarding implementation, whether I should use exceptions or results, using a real database or in memory persistence etc, but I made some decisions that we can discuss if necessary. 

Anyway, I would appreciate any kind of feedback from your team so I can improve my skills.

## Features

- Show all choices
- Get random choice
- Play game
- Show scoreboard
- Reset scoreboard

## Tech Stack

**Server:** dotnet 8, C#

## Prerequisites

- dotnet 8

## Run Locally

Clone the project

```bash
  git clone https://github.com/djordjedjukic/choice-smash.git
```

Go to the project directory

```bash
  cd src
```

Start the server

```bash
  dotnet run
```

Open API doc in browser

```bash
  localhost:port/swagger
```

## Run with docker

Clone the project

```bash
  git clone https://github.com/djordjedjukic/choice-smash.git
```

Run docker compose

```bash
  docker compose up -d
```

Open API doc in browser

```bash
  localhost:8080/swagger
```

> [!NOTE]  
> You can modify `docker-compose.yml` file to modify port if needed.

## Running Unit Tests

To run unit tests, run the following commands

```bash
  cd tests/UnitTests
```
```bash
  dotnet tests
```

## Running Integration Tests

To run integration tests, run the following commands

```bash
  cd tests/IntegrationTests
```
```bash
  dotnet tests
```

## API Reference

#### Get all choices

```http
  GET /choices
```

#### Get random choice

```http
  GET /choice
```

#### Play game

```http
  POST /play
```

| Key       | Type     | Description                            |
| :-------- | :------- | :------------------------------------- |
| `player`   | `int` | The ID of the player choice. |

### Example

```json
POST /play
Content-Type: application/json

{
  "player": 1,        
}

#### Get scoreboard

```http
  GET /scoreboard
```

#### Reset scoreboard

```http
  POST /reset
```
