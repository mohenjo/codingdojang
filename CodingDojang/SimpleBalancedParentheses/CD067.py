# python 3.6
inp = ["(()()()())", "(((())))", "(()((())()))",
       "((((((())", "()))", "(()()(()", "(()))(", "())(()"]


def chk_bracket(string):
    balance = 0
    check = True
    for c in string:
        if c == "(":
            balance += 1
        elif c == ")":
            balance -= 1
        if balance < 0:
            check = False
            break
    if balance != 0:
        check = False
    return check


for s in inp:
    print(s, chk_bracket(s))