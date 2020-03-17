import numpy as np
import cv2
import math
import socket
import time

UDP_IP = "127.0.0.1"
UDP_PORT = 9999
while True:
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    t = input()
    if t == "f":
       sock.sendto(("f").encode(), (UDP_IP, UDP_PORT))
    if t == "b":
       sock.sendto(("b").encode(), (UDP_IP, UDP_PORT))
    else:
        pass

