# iot-control
Sample for IoT control and data retrieval

Sample to better understand lots of technologies: akka.net, .net core web api dev etc.

Basic design is user facing REST API at the BASE, which tasks multiple internet facing workers that talk to servers that talk to the end IoT devices to send requests, retrieve data and logs and stuff. The BASE is split in two (Inside and Outside) so that some security can be added if required by segregating the actual user-facing application from the internet facing workers (which are on the Outside).
