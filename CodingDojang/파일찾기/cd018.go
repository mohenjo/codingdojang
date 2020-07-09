/* 파일찾기 */
package main

import (
	"fmt"
	"io/ioutil"
	"os"
	"path/filepath"
	"strings"
)

func main() {
	rootpath := "C:/MyApp"
	ext := ".txt"
	chkString := "LIFE IS TOO SHORT"

	for _, v := range Search(rootpath, ext, chkString) {
		fmt.Println(v)
	}
}

func Search(rootpath, ext, chkString string) []string {
	rst := []string{}
	pool, ok := getFileList(rootpath, ext)
	if !ok {
		fmt.Println("Not found any file with ext: ", ext)
		os.Exit(0)
	}
	for _, v := range pool {
		if chkFile(v, chkString) {
			rst = append(rst, v)
		}
	}
	if len(rst) == 0 {
		rst = append(rst, "No such file.")
	}
	return rst
}

// chkFile: filename 파일 내의 chkString 존재여부 반환
func chkFile(filename, chkString string) bool {
	bs, err := ioutil.ReadFile(filename)
	if err != nil {
		fmt.Printf("check file error: [%v]\n", err)
		os.Exit(0)
	}
	str := string(bs)
	return strings.Contains(str, chkString)
}

// getFileList: ext 확장자를 가진 파일의 슬라이스 및 존재여부 반환
func getFileList(rootpath, ext string) ([]string, bool) {
	list := []string{}
	rst := filepath.Walk(rootpath, func(path string, info os.FileInfo, err error) error {
		if err != nil {
			return err
		}
		if strings.ToLower(filepath.Ext(path)) == ext {
			list = append(list, path)
		}
		return nil
	})
	if rst != nil {
		fmt.Printf("File walk error: [%v]\n", rst)
		os.Exit(0)
	}
	ok := true
	if len(list) == 0 {
		ok = false // 확장자의 파일이 존재하지 않을 경우
	}
	return list, ok
}
