# 두 지도의 정수 값에 대해 OR 연산 => 연산된 (길이=size의) 이진문자열에 대해 문자 치환
def unveil_map(size, map1, map2):
    rst = [binary.zfill(n).replace("1", "#").replace("0", " ") for binary in
           (bin(map1[i] | map2[i])[2:] for i in range(size))]
    return rst


# 예제1
n = 5
arr1 = [9, 20, 28, 18, 11]
arr2 = [30, 1, 21, 17, 28]
print(unveil_map(n, arr1, arr2))

# 예제2
n = 6
arr1 = [46, 33, 33, 22, 31, 50]
arr2 = [27, 56, 19, 14, 14, 10]
print(unveil_map(n, arr1, arr2))
