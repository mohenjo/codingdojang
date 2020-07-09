# python 3.6
def camel2pothole(string):
    rst = "".join(["_" + s.lower() if s == s.upper() or s.isdigit() else s for s in string])
    return rst


print(camel2pothole("codingDojang"))
print(camel2pothole("numGoat30"))