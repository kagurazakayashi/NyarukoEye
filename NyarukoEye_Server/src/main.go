package main // 主函数必须在main包中

import (
	"encoding/json"
	"fmt" // 多文件编程，可以通过命令行进行编译： go build main.go myfunc.go  （将多个文件当成一个整体进行编译）
	"io"
	"io/ioutil"
	"log"
	"net"
	"net/http"
	"os"
	"os/signal"
	"strings"
	"syscall"
)

// go build ./src  （多文件编程，将指定目录下的所有文件整体进行编译）

// var handlepath string
// var listenandserve string

// type configuration struct {
// 	handlepath     string
// 	listenandserve string
// 	filepath       string
// }

// var conf = configuration{}

var confs = map[string]string{}

func readFile(filename string) (map[string]string, error) {
	bytes, err := ioutil.ReadFile(filename)
	if err != nil {
		fmt.Println("ReadFile: ", err.Error())
		return nil, err
	}

	if err := json.Unmarshal(bytes, &confs); err != nil {
		fmt.Println("Unmarshal: ", err.Error())
		return nil, err
	}

	return confs, nil
}
func main() {
	// flag.StringVar(&handlepath, "hp", "punch_the_clock", "默认访问路径")
	// flag.StringVar(&listenandserve, "ls", "1818", "默认端口")
	// flag.Parse()

	conf, err := readFile("rsa_server_conf.json")
	if err != nil {
		fmt.Println("readFile: ", err.Error())
		return
	}

	// file, _ := os.Open("rsa_server_conf.json")
	// defer file.Close()

	// decoder := json.NewDecoder(file)
	// conf = configuration{}
	// err := decoder.Decode(&conf)
	// if err != nil {
	// 	fmt.Println("Error:", err)
	// }
	// fmt.Println("file:", decoder)
	// fmt.Println("handlepath:", conf.handlepath)
	// fmt.Println("listenandserve:", conf.listenandserve)
	// fmt.Println("filepath:", conf.filepath)
	// http.HandleFunc("/", sayhelloName)     //设置访问的路由
	fmt.Println("STRART 0wew0_RSA_Server v1.0")
	fmt.Println("访问路径:" + conf["handlepath"])
	fmt.Println("端口:" + conf["listenandserve"])

	http.HandleFunc("/"+conf["handlepath"], mainHandleFunc)
	err = http.ListenAndServe(":"+conf["listenandserve"], nil) //设置监听的端口
	// check("ListenAndServe", err)
	if err != nil {
		log.Fatal("ListenAndServe:", err)
	}
}

func mainHandleFunc(w http.ResponseWriter, req *http.Request) {
	fmt.Println("loginTask is running...")

	// //模拟延时
	// time.Sleep(time.Second * 2)

	// 检查是否为post请求
	if req.Method != http.MethodPost {
		w.WriteHeader(http.StatusMethodNotAllowed)
		fmt.Fprintf(w, "invalid_http_method")
		return
	}

	req.ParseMultipartForm(32 << 20)
	// if req.MultipartForm != nil {
	// 	// values := req.MultipartForm
	// 	fmt.Fprint(w, req.MultipartForm)
	// 	return
	// }

	//获取客户端通过GET/POST方式传递的参数
	// req.ParseForm()
	// fmt.Fprint(w, values)
	paramUserName, found1 := req.Form["userName"]
	paramPassword, found2 := req.Form["password"]
	// paramTime := req.MultipartForm.Value["runTime"]
	extension := req.MultipartForm.Value["extension"]
	// paramFile, found3 := req.Form["files"]
	// fmt.Fprint(w, len(paramUserName[0]))
	// fmt.Fprint(w, "\n")
	// fmt.Fprint(w, len(paramPassword[0]))
	// fmt.Fprint(w, "\n")
	if !(found1 && found2) {
		fmt.Fprint(w, "请勿非法访问")
		return
	}
	extensionstring := "jpg"
	if strings.Join(extension, "") != "" {
		extensionstring = strings.Join(extension, "")
	}
	// paramTimeInt := 1
	// paramTimeString := strings.Join(paramTime, "")
	// paramTimeInt, err := strconv.Atoi(paramTimeString)
	// if err != nil {
	// 	fmt.Println("字符串转换成整数失败")
	// }
	// if !(found3) {
	// 	fmt.Fprint(w, "没有文件")
	// } else {
	// 	fmt.Fprint(w, "有文件")
	// }

	// result := NewBaseJsonBean()
	result := 000

	userName := paramUserName[0]
	password := paramPassword[0]

	// s := "userName:" + userName + ",password:" + password
	// fmt.Println(s)
	reip := ClientIP(req)
	if userName == confs["uname"] && password == confs["password"] {

		// 调用当前包(目录)中的其他函数。 其他包中的函数通过 包名.函数名()的方式调用（需要import导入包）
		tarr := getdate()
		// fmt.Println(gettime())
		// Linux
		// tstring := "." + confs["filepath"]
		// windows
		tstring := confs["filepath"]
		_, err := newfilefolder(tstring)
		if err != nil {
			fmt.Fprint(w, "文件夹创建失败\n")
			return
		}
		tstring += "/" + reip
		_, err = newfilefolder(tstring)
		if err != nil {
			fmt.Fprint(w, "文件夹创建失败\n")
			return
		}
		for _, value := range tarr {
			//fmt.Println(index, "\t",value)
			tstring += "/" + value
			// fmt.Println(tstring)
			_, err = newfilefolder(tstring)
			if err != nil {
				fmt.Fprint(w, "文件夹创建失败\n")
				return
			}
		}
		// fmt.Println(tstring)
		filePath := "e"
		fileName := "name"
		keyPath := "enc"
		//设置内存大小
		req.ParseMultipartForm(32 << 20)
		//获取上传的文件组
		files := req.MultipartForm.File["files"]
		fileslen := len(files)
		// fmt.Printf("fileslen: %v\n", fileslen)
		for i := 0; i < fileslen; i++ {
			//打开上传文件
			file, err := files[i].Open()
			if err != nil {
				log.Fatal(err)
			}
			fnarr := strings.Split(files[i].Filename, ".")
			if len(fnarr[1]) == 1 {
				filePath = tstring + "/" + files[i].Filename
				fileName = files[i].Filename
				//创建上传文件
				cur, err := os.Create(filePath)
				if err != nil {
					// result.Code = 202
					// result.Ip = reip
					// result.Extension = extensionstring
					// result.Runtime = paramTimeInt
					// result.Message = "创建文件失败"
					result = 202
					fmt.Fprint(w, result)
					return
				}
				if err != nil {
					log.Fatal(err)
				}

				_, err = io.Copy(cur, file)
				if err != nil {
					// result.Code = 203
					// result.Ip = reip
					// result.Extension = extensionstring
					// result.Runtime = paramTimeInt
					// result.Message = "保存文件失败"
					result = 203
					fmt.Fprint(w, result)
					return
				}
				cur.Close()
			} else {
				keyPath = tstring + "/" + files[i].Filename
				//创建上传文件
				cur, err := os.Create(keyPath)
				if err != nil {
					// result.Code = 202
					// result.Ip = reip
					// result.Extension = extensionstring
					// result.Runtime = paramTimeInt
					// result.Message = "创建文件失败"
					// return
					result = 202
					fmt.Fprint(w, result)
					return
				}
				if err != nil {
					log.Fatal(err)
				}

				_, err = io.Copy(cur, file)
				if err != nil {
					// result.Code = 203
					// result.Ip = reip
					// result.Extension = extensionstring
					// result.Runtime = paramTimeInt
					// result.Message = "保存文件失败"
					result = 203
					fmt.Fprint(w, result)
					return
				}
				cur.Close()
			}
			file.Close()
		}
		// fmt.Printf("filePath:" + filePath + "\n")
		// fmt.Printf("fileName:" + fileName + "\n")
		// fmt.Printf("keyPath:" + keyPath + "\n")
		// // 根据字段名获取表单文件
		// formFile, header, err := req.FormFile("uploadfile")
		// if err != nil {
		// 	result.Code = 201
		// 	result.Ip = reip
		// 	result.Extension = extensionstring
		// 	result.Runtime = paramTimeInt
		// 	result.Message = "文件获取失败"
		// 	return
		// }
		// defer formFile.Close()
		// // 创建保存文件
		// tstring += "/" + header.Filename
		// destFile, err := os.Create(tstring)
		// if err != nil {
		// 	result.Code = 202
		// 	result.Ip = reip
		// 	result.Extension = extensionstring
		// 	result.Runtime = paramTimeInt
		// 	result.Message = "创建文件失败"
		// 	return
		// }
		// defer destFile.Close()

		// // 读取表单文件，写入保存文件
		// _, err = io.Copy(destFile, formFile)
		// if err != nil {
		// 	result.Code = 203
		// 	result.Ip = reip
		// 	result.Extension = extensionstring
		// 	result.Runtime = paramTimeInt
		// 	result.Message = "保存文件失败"
		// 	return
		// }
		toPatharr := strings.Split(filePath, ".")
		toPatharr[(len(toPatharr) - 1)] = extensionstring
		toPath := strings.Join(toPatharr, ".")
		// fmt.Printf("paramTime:[%v]\n", paramTimeInt)
		// Linux
		// isdone, returnstring, err := rsabatDecrypt(confs["filepath"], keyPath, filePath, toPath, fileName, tarr, reip)
		// windows
		isdone, returnstring, err := rsacmdDecrypt(confs["filepath"], keyPath, filePath, toPath, fileName, tarr, reip)
		if returnstring != "" {
			fmt.Println(returnstring)
		}
		// fmt.Printf("keyPath:[%v]\nkeyPath:[%v]\nkeyPath:[%v]\nkeyPath:[%v]\n", keyPath, filePath, toPath, paramTimeInt)
		if isdone {
			if err != nil {
				// result.Code = 101
				// result.Ip = reip
				// result.Extension = extensionstring
				// result.Runtime = paramTimeInt
				// result.Message = "上传成功,原文件删除失败"
				result = 101
			}
			// result.Code = 100
			// result.Ip = reip
			// result.Extension = extensionstring
			// result.Runtime = paramTimeInt
			// result.Message = "上传成功"
			result = 100
		} else {
			// result.Code = 204
			// result.Ip = reip
			// result.Extension = extensionstring
			// result.Runtime = paramTimeInt
			// result.Message = "解密失败"
			result = 204
		}
	} else {
		// result.Code = 200
		// result.Ip = reip
		// result.Extension = extensionstring
		// result.Runtime = paramTimeInt
		// result.Message = "用户名或密码不正确"
		result = 200
	}

	//向客户端返回JSON数据
	// bytes, _ := json.Marshal(result)
	// fmt.Fprint(w, string(bytes))
	fmt.Fprint(w, result)
}

// ClientIP 尽最大努力实现获取客户端 IP 的算法。
// 解析 X-Real-IP 和 X-Forwarded-For 以便于反向代理（nginx 或 haproxy）可以正常工作。
func ClientIP(r *http.Request) string {
	xForwardedFor := r.Header.Get("X-Forwarded-For")
	ip := strings.TrimSpace(strings.Split(xForwardedFor, ",")[0])
	if ip != "" {
		return ip
	}

	ip = strings.TrimSpace(r.Header.Get("X-Real-Ip"))
	if ip != "" {
		return ip
	}

	if ip, _, err := net.SplitHostPort(strings.TrimSpace(r.RemoteAddr)); err == nil {
		return ip
	}

	return ""
}

func setupCloseHandler() {
	c := make(chan os.Signal, 2)
	signal.Notify(c, os.Interrupt, syscall.SIGTERM)
	go func() {
		<-c
		fmt.Println("\r- Ctrl+C pressed in Terminal")
		os.Exit(0)
	}()
}

//对错误检查的封装
func check(w http.ResponseWriter, msg string, err error) {
	if err != nil {
		// log.Fatal(msg, ":", err)
		errmsg := fmt.Sprintf("%s:%s", msg, err)
		fmt.Fprintf(w, errmsg)
	}
}
