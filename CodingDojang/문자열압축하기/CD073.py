# python 3.6
string = "aaabbcccccca"
cnv = ("".join([string[i] if string[i] == string[i + 1]
                else string[i] + "," for i in range(len(string) - 1)]) + string[-1]).split(",")
cmpd = "".join([s[0] + str(len(s)) for s in cnv])
print(cmpd)