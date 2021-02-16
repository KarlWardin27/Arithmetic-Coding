#Developed By   
#Prathamesh Pokhare

def main():
    l1 = list(input("Enter your Message to be Encoded:- "))
    l2 = list(dict.fromkeys(l1))

    #The message to sorted to ascending order so that we can generalize the same algorithm for every string.
    l2.sort()
    prob = list()
    ran = list()
    H=0.0
    L=0.0
    ran.append(0)

    #Encoding Algorithm

    #Finding Probabilities for each alphabet
    for x in range(len(l2)):
        temp = 0
        for y in range(len(l1)):
            if l1[y]==l2[x]:
                temp = temp + 1
        prob.append(temp/len(l1))
        ran.append(ran[x]+prob[x])
    print("The Probabilites for each alphabet :- ")
    print(prob)

    #Generation of TAG
    for x in range(len(l1)):
        if x == 0:
            L=0+((1-0)*ran[l2.index(l1[x])])
            H=0+((1-0)*ran[l2.index(l1[x])+1])
        else:
            temp = L+((H-L)*ran[l2.index(l1[x])])
            H = L+((H-L)*ran[l2.index(l1[x])+1])
            L=temp
    print('TAG = '+ str((H+L)/2))
    print("\n")
    TAG = (H+L)/2

    #Decoding Algorithm
    print("\n############ Decoding the encoded message with length of the Message, probability of each alphabet and TAG Generated ###########")
    OPstr = ""
    temp = 0 
    for x in range(len(l1)):
        for y in range(len(ran)):
            if ran[y] >= TAG:
                OPstr = OPstr + l2[y-1]
                TAG = (TAG-ran[y-1])/(ran[y]-ran[y-1])
                break
    print("The Encode Message is :- "+OPstr)
    
if __name__ == "__main__":
    main()