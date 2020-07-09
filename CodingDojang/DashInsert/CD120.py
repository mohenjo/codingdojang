# python 3.6
def DashInsert(inp):
    """inp: number in string type"""
    rst = inp[0]
    vl = int(rst)
    for i in range(1, len(inp)):
        vr = int(inp[i])
        if vl % 2 == 0 and vr % 2 == 0:
            rst += "*"
        if vl % 2 == 1 and vr % 2 == 1:
            rst += "-"
        rst += str(vr)
        vl = vr
    return rst


print(DashInsert(input()))