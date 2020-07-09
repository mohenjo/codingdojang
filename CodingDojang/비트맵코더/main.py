from itertools import groupby


def main():
    bc = BitmapCoder()
    print(bc)


class BitmapCoder:
    def __init__(self):
        self._reader()

    def _reader(self):
        (self.height, self.width) = (int(s) for s in input("Height & Width: ").strip().split())
        self.matrix = []

        for h in range(self.height):
            lineinput = input().strip().replace(" ", "")
            self.matrix.append(BitmapCoder._string2chunklist(lineinput))

    def __str__(self):
        return "\n".join(self.matrix)

    @staticmethod
    def _string2chunklist(inputstr: str) -> str:
        rst = [str(len(list(g))) for _, g in groupby(inputstr)]
        if inputstr[0] == "1":
            rst.insert(0, "0")
        return " ".join(rst)


if __name__ == '__main__':
    main()
