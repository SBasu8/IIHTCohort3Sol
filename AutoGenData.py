import random as r
#didnt use pandas as using it would create csv file not excel & back end parses excel not csv
import xlsxwriter

wkbk = xlsxwriter.Workbook('Stock_Price.xlsx')
wksht =wkbk.add_worksheet()
print(wkbk)

row=0
col=0
head =['Company Code','Stock Exchange','Price Per Share(in Rs)','Date','Time']

#9am-3pm
day=1

hh=9
mm=0

lpar=[]
while(True):
    l=[]
    
    c_id = 1
    if(c_id==1):  se_id="BSE"
    price = r.randrange(340,370)
    
    if(mm==60):
        mm=0
        hh+=1
    if(hh==15 and mm>0):
        hh=9
        day+=1

    if(day==31): break
    
    if(day>=0 and day<=9):  date="0"+str(day)+"-"
    else: date=str(day)+"-"
    date+="08-2020"
    
    if(hh>=0 and hh<=9):  time="0"+str(hh)+":"
    else: time=str(hh)+":"
    if(mm>=0 and mm<=9):  time+="0"+str(mm)+":"
    else: time+=str(mm)+":"
    time+="00"
    #print(time)
    l.append(c_id);
    l.append(se_id);
    l.append(price);
    l.append(date);
    l.append(time);

    mm+=30

    lpar.append(l)
    l=[]

day=1

hh=9
mm=0

while(True):
    l=[]
    
    c_id = 3
    if(c_id==3):  se_id="NSE"
    price = r.randrange(340,370)
    
    if(mm==60):
        mm=0
        hh+=1
    if(hh==15 and mm>0):
        hh=9
        day+=1

    if(day==31): break
    
    if(day>=0 and day<=9):  date="0"+str(day)+"-"
    else: date=str(day)+"-"
    date+="08-2020"
    
    if(hh>=0 and hh<=9):  time="0"+str(hh)+":"
    else: time=str(hh)+":"
    if(mm>=0 and mm<=9):  time+="0"+str(mm)+":"
    else: time+=str(mm)+":"
    time+="00"
    #print(time)
    l.append(c_id);
    l.append(se_id);
    l.append(price);
    l.append(date);
    l.append(time);

    mm+=30

    lpar.append(l)
    l=[]
#for i in lpar: print(i)

for i in range(0,len(head)):
    wksht.write(0,i,head[i]);
row=1
for l in lpar:    
    for i in range(0,len(l)):
        wksht.write(row,col+i,l[i])
    row+=1


wkbk.close()

