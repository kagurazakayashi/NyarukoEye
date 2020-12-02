package main

import (
	"bytes"
	"fmt"
	"io/ioutil"
	"log"
	"os"
	"os/exec"
	"strings"
)

func rsacmdDecrypt(mainPath string, keyPath string, rsaPath string, toPath string, filename string, date []string, reip string) (bool, string, error) {

	//生成sh路径
	filenamearr := strings.Split(filename, ".")
	filenamearr[(len(filenamearr) - 1)] = "sh"
	// shPath := "." + mainPath + "/" + reip + "/" + strings.Join(date, "/") + "/" + strings.Join(filenamearr, ".")
	//生成log路径
	datestring := mainPath + "/" + reip + "/" + strings.Join(date, "/")
	datestring += "/" + strings.Join(date, "-") + ".log"

	keyPatharr := strings.Split(keyPath, ".")
	keyPatharr[(len(keyPatharr) - 1)] = "bin"
	enckeyPath := strings.Join(keyPatharr, ".")

	isfile, _ := PathExists(datestring)
	var file *os.File
	if isfile {
		file, _ = os.OpenFile(datestring, os.O_RDWR|os.O_CREATE|os.O_APPEND, 0766)
	} else {
		file, _ = os.Create(datestring)
	}
	defer file.Close()
	log.SetOutput(file) // 将文件设置为log输出的文件
	log.SetPrefix("[cmd]")
	log.SetFlags(log.LstdFlags | log.Lshortfile | log.LUTC)

	key := "file:" + enckeyPath
	sh := "openssl " + "rsautl " + "-decrypt " + "-inkey " + "rsa_private_key.pem " + "-in " + keyPath + " -out " + enckeyPath + "&& " + "openssl " + "enc " + "-d " + "-aes-256-cbc " + "-pbkdf2 " + "-in " + rsaPath + " -out " + toPath + " -pass " + key + " && " + "echo " + "===== "

	// rsaPatharr := strings.Split(rsaPath, "/")
	// rsaPaths := strings.Join(rsaPatharr, "\\")
	// keyPatharr = strings.Split(keyPath, "/")
	// keyPath = strings.Join(keyPatharr, "\\")
	// enckeyPatharr := strings.Split(enckeyPath, "/")
	// enckeyPath = strings.Join(enckeyPatharr, "\\")
	// sh += " && " + "del " + "/F \"" + rsaPaths + " " + keyPath + " " + enckeyPath + "\""

	// fmt.Println(sh)
	log.Println(sh)

	var outInfo bytes.Buffer
	var errInfo bytes.Buffer
	cmd := exec.Command("cmd", "/C", sh)
	cmd.Stdout = &outInfo
	cmd.Stderr = &outInfo
	cmd.Run()
	cmd.Wait()
	fmt.Println(outInfo.String())
	if errInfo.String() != "" {
		log.Println(outInfo.String())
		log.Println(errInfo.String())
		fmt.Println(sh)
	} else {
		log.Println(outInfo.String())
		err := os.Remove(rsaPath)
		if err != nil {
			fmt.Println(err)
		}
		err = os.Remove(keyPath)
		if err != nil {
			fmt.Println(err)
		}
		err = os.Remove(enckeyPath)
		if err != nil {
			fmt.Println(err)
		}
	}

	// cmd = exec.Command("openssl " + "rsautl " + "-decrypt " + "-inkey " + "rsa_private_key.pem " + "-in " + keyPath + " -out " + enckeyPath)
	// cmd.Stdout = &outInfo
	// cmd.Run()
	// log.Println(outInfo.String())

	// cmd = exec.Command("openssl " + "enc " + "-d " + "-aes-256-cbc " + "-pbkdf2 " + "-in " + rsaPath + " -out " + toPath + " -pass " + key)
	// cmd.Stdout = &outInfo
	// cmd.Run()
	// log.Println(outInfo.String())

	// stdout, err := cmd.StdoutPipe()
	// // check(0, "cmd.StdoutPipe", err)
	// if err != nil {
	// 	fmt.Printf("msg:cmd.StdoutPipe\nerror:%s\n", err)
	// 	// if code == 1 {
	// 	// 	os.Exit(code)
	// 	// }
	// 	return false, "", err
	// }
	// defer stdout.Close()

	// err = cmd.Run() //.Start()
	// // check(0, "cmd.Start", err)
	// if err != nil {
	// 	fmt.Printf("msg:cmd.StdoutPipe\nerror:%s\n", err)
	// 	// if code == 1 {
	// 	// 	os.Exit(code)
	// 	// }
	// 	return false, "", err
	// }
	// opBytes, err := ioutil.ReadAll(stdout)
	// if err != nil {
	// 	fmt.Printf("msg:ioutil.ReadAll\nerror:%s\n", err)
	// 	// os.Exit(1)
	// 	return false, string(opBytes), err
	// }
	// fmt.Println(string(opBytes))

	// cmd = exec.Command("openssl", "enc", "-d", "-aes-256-cbc", "-pbkdf2", "-in", rsaPath, "-out", toPath, "-pass", sh)
	// fmt.Println(cmd)
	// stdout, err = cmd.StdoutPipe()
	// // check(0, "cmd.StdoutPipe", err)
	// if err != nil {
	// 	fmt.Printf("msg:cmd.StdoutPipe\nerror:%s\n", err)
	// 	// if code == 1 {
	// 	// 	os.Exit(code)
	// 	// }
	// 	return false, "", err
	// }
	// defer stdout.Close()
	// err = cmd.Start()
	// // check(0, "cmd.Start", err)
	// if err != nil {
	// 	fmt.Printf("msg:cmd.StdoutPipe\nerror:%s\n", err)
	// 	// if code == 1 {
	// 	// 	os.Exit(code)
	// 	// }
	// 	return false, "", err
	// }
	// opBytes, err = ioutil.ReadAll(stdout)
	// if err != nil {
	// 	fmt.Printf("msg:ioutil.ReadAll\nerror:%s\n", err)
	// 	// os.Exit(1)
	// 	return false, string(opBytes), err
	// }
	// fmt.Println(string(opBytes))
	return true, "", nil
}

func rsashDecrypt(mainPath string, keyPath string, rsaPath string, toPath string, filename string, date []string, reip string) (bool, string, error) {
	// println(shPath)

	//生成sh路径
	filenamearr := strings.Split(filename, ".")
	filenamearr[(len(filenamearr) - 1)] = "sh"
	shPath := "." + mainPath + "/" + reip + "/" + strings.Join(date, "/") + "/" + strings.Join(filenamearr, ".")
	//生成log路径
	datestring := "." + mainPath + "/" + reip + "/" + strings.Join(date, "/")
	datestring += "/" + strings.Join(date, "-") + ".log"
	//生成key路径
	// fmt.Printf("shPath:" + shPath + "\n")
	// fmt.Printf("datestring:" + datestring + "\n")

	keyPatharr := strings.Split(keyPath, ".")
	keyPatharr[(len(keyPatharr) - 1)] = "bin"
	enckeyPath := strings.Join(keyPatharr, ".")

	sh := fmt.Sprintf("cat %s >>%s && echo >>%s && date >>%s && openssl rsautl -decrypt -inkey rsa_private_key.pem -in %s -out %s >>%s 2>&1 && openssl enc -d -aes-256-cbc -pbkdf2 -in %s -out %s -pass file:%s >>%s 2>&1 && echo ===== >> %s && rm -f %s && rm -f %s && rm -f %s && rm -f %s", shPath, datestring, datestring, datestring, keyPath, enckeyPath, datestring, rsaPath, toPath, enckeyPath, datestring, datestring, rsaPath, keyPath, enckeyPath, shPath)
	content := []byte(sh)
	err := ioutil.WriteFile(shPath, content, 0777)
	if err != nil {
		fmt.Printf("msg:ioutil.WriteFile\nerror:%s\n", err)
		// os.Exit(1)
		return false, "", err
	}
	cmd := exec.Command("sh", shPath)
	// println(shPath)
	// println(datestring)
	stdout, err := cmd.StdoutPipe()
	if err != nil {
		fmt.Printf("msg:cmd.StdoutPipe\nerror:%s\n", err)
		// os.Exit(1)
		return false, "", err
	}
	defer stdout.Close()
	err = cmd.Start()
	if err != nil {
		fmt.Printf("msg:cmd.Start\nerror:%s\n", err)
		// os.Exit(1)
		return false, "", err
	}
	opBytes, err := ioutil.ReadAll(stdout)
	if err != nil {
		fmt.Printf("msg:ioutil.ReadAll\nerror:%s\n", err)
		// os.Exit(1)
		return false, string(opBytes), err
	}
	// fmt.Println(string(opBytes))
	return true, "", err

}

// //对错误检查的封装
// func check(code int, msg string, err error) {
// 	if err != nil {
// 		fmt.Printf("msg:%s\nerror:%s\n", msg, err)
// 		if code == 1 {
// 			os.Exit(code)
// 		}
// 	}
// }
