def main():
    bp = BitmapPrinter()
    print(bp)


class BitmapPrinter:
    def __init__(self):
        self._reader()

    def _reader(self):
        (self.height, self.width) = (int(s) for s in input("Height & Width: ").strip().split())
        self.matrix = []

        for h in range(self.height):
            lineinput = (int(s) for s in input().strip().split())
            newstr = [("□" if i % 2 == 0 else "■") * v for i, v in enumerate(lineinput)]
            self.matrix.append(" ".join("".join(newstr)))

    def __str__(self):
        return "\n".join(self.matrix)


if __name__ == '__main__':
    main()
