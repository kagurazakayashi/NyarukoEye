package main

import (
	"strings"
	"time"
)

func getdate() []string {
	t := time.Now().Format("2006-01-02")
	timearr := strings.Split(t, "-")
	return timearr
}

func gettime() string {
	t := time.Now().Format("20060102150405")
	// timearr := strings.Split(t, "-")
	return t
}
