package main

import (
	"fmt"
	"io/ioutil"
	"os/exec"
	"strings"
)

// func rsabatDecrypt(keyPath string, rsaPath string, toPath string, runtime int) (bool, error) {
// 	fmt.Printf("keyPath:%v", keyPath)

// 	var wg sync.WaitGroup

// 	wg.Add(1)
// 	reTurn := false
// 	reErr := error(nil)
// 	go func() {
// 		// screenshotpath := fmt.Sprintf("%s/%s.jpg", todir, toname)
// 		cmd := exec.Command("openssl", "rsautl", "-decrypt", "-in", rsaPath, "-inkey", "rsa_private_key.pem", "-out", toPath)
// 		stdout, err := cmd.StdoutPipe()
// 		// check(0, "cmd.StdoutPipe", err)
// 		if err != nil {
// 			fmt.Printf("msg:cmd.StdoutPipe\nerror:%s\n", err)
// 			// if code == 1 {
// 			// 	os.Exit(code)
// 			// }
// 			reTurn = false
// 			reErr = err
// 		}
// 		defer stdout.Close()
// 		err = cmd.Start()
// 		// check(0, "cmd.Start", err)
// 		if err != nil {
// 			fmt.Printf("msg:cmd.StdoutPipe\nerror:%s\n", err)
// 			// if code == 1 {
// 			// 	os.Exit(code)
// 			// }
// 			reTurn = false
// 			reErr = err
// 		}
// 		reTurn = true
// 		reErr = err
// 		fmt.Printf("解密完成\n")
// 		time.Sleep(time.Second * time.Duration(runtime))
// 		defer wg.Done()
// 	}()
// 	wg.Wait()
// 	fmt.Printf(rsaPath + "\n删除源文件\n")
// 	err := os.Remove(rsaPath)
// 	if err != nil {
// 		fmt.Printf("msg:cmd.StdoutPipe\nerror:%s\n", err)
// 		// if code == 1 {
// 		// 	os.Exit(code)
// 		// }
// 		return false, "", err
// 	}
// 	return reTurn, reErr
// }
func rsabatDecrypt(mainPath string, keyPath string, rsaPath string, toPath string, filename string, date []string, reip string) (bool, string, error) {
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
