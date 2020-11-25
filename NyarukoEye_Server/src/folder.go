package main

import (
	"fmt"
	"os"
)

func newfilefolder(path string) (bool, error) {
	exist, err := PathExists(path)
	if err != nil {
		fmt.Printf("没有这个文件夹：[%v]准备创建\n", err)
	}

	if exist {
		// fmt.Printf("有这个文件夹：[%v]\n", path)
		return true, nil
	} else {
		// fmt.Printf("没有这个文件夹：[%v]\n", path)
		// 创建文件夹
		err := os.Mkdir(path, os.ModePerm)
		if err != nil {
			// fmt.Printf("创建失败：[%v]\n", err)
			return false, err
		} else {
			// fmt.Printf("创建成功！\n")
			return true, nil
		}
	}
}

// 判断文件夹是否存在
func PathExists(path string) (bool, error) {
	_, err := os.Stat(path)
	if err == nil {
		return true, nil
	}
	if os.IsNotExist(err) {
		return false, err
	}
	return false, err
}
