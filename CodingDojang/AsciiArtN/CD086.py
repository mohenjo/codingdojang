# python 3.6
n = int(input())
string = [["N" if x == 0 or x == (
    n - 1) else " " for x in range(n)] for y in range(n)]
for i in range(n):
    string[i][i] = "N"
string = "\n".join(["".join(lst) for lst in string])
print(string)
