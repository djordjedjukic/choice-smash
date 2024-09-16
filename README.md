# choice-smash
ChoiceSmash is an implementation of the classic “Rock, Paper, Scissors, Lizard, Spock” game, designed for interview purposes.

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
  cd choice-smash/src
```

Start the server

```bash
  dotnet run
```

Open API doc in browser

```bash
  localhost:port//swagger
```

## Run with docker

Clone the project

```bash
  git clone https://github.com/djordjedjukic/choice-smash.git
```

Go to the project directory

```bash
  cd choice-smash
```

Run docker compose

```bash
  docker compose up -d
```

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
