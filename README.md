# ClipboardOCR
Quickly convert an image copied to clipboard into text using Microsoft Azure Congitive Services for Vision

Endpoint and Key configuration is hard coded for now. Put your key and url in the code.

Suggested Improvements:
* Better error handling / logging (do not log copied text for compliance reasons)
* Better secret management - pull secrets from a known file location for easy rotation.
* API cost is $2.50 / 1000 calls - why not track cost per client?
* Implement timeout to clear converted text from clipboard after x minutes for security purposes.
* Visual improvements, auto start, system tray icon, etc....

