FROM ubuntu:jammy AS base

RUN apt update

WORKDIR /home/
RUN mkdir project2
WORKDIR /home/project2

COPY . .
RUN ls

RUN ./ECE461-Project-Part1-Handoff-CLI/run install && ./ECE461-Project-Part1-Handoff-CLI/run build
RUN ./run install && ./run build