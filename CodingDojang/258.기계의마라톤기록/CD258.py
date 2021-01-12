import datetime

record: float = 42.195 * 10 ** 3 / (100 / float(input('100m 기록(sec): ')))
print(f"마라톤 기록(h:m:s): {str(datetime.timedelta(seconds=record))}")
