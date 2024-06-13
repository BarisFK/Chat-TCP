# TCP Chat Application

This repository contains a simple TCP chat application in C#. It includes a server and a client that can communicate over a TCP connection.

## Requirements

- [.NET Core SDK](https://dotnet.microsoft.com/download)

## Usage

### Running the Server

1. Open a terminal.
2. Navigate to the directory containing `Server.cs`.
3. Compile the server code:
    ```sh
    csc Server.cs
    ```
4. Run the server:
    ```sh
    Server.exe
    ```

### Running the Client

1. Open another terminal.
2. Navigate to the directory containing `Client.cs`.
3. Compile the client code:
    ```sh
    csc Client.cs
    ```
4. Run the client:
    ```sh
    Client.exe
    ```

## How It Works

### Server

- Listens for incoming connections on `127.0.0.1:23000`.
- Accepts a client connection and communicates using a `NetworkStream`.
- Reads messages from the client and sends responses.
- Stops when the message "tamam" is received.

### Client

- Connects to the server at `127.0.0.1:23000`.
- Sends user input to the server and displays responses.
- Stops when the message "tamam" is sent or received.

