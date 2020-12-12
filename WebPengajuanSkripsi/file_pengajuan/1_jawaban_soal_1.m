clear; clc;
X = xlsread('soal1'); 
%harus pada 1 folder yang sama

%Persen = Command

[n,p] = size(X); %n = Jumlah baris, p = Jumlah kolom

XA = X(:, 1:3) %Ambil Data di X, Baris sembarang, Kolom 1,2,3
XB = X(:, 4:6)
XC = X(:, 7:9)

RXA = mean(XA); %Vektor rata" dari kelas A
RXB = mean(XB); %Vektor rata" dari kelas B
RXC = mean(XC); %Vektor rata" dari kelas C

SXA = cov(XA); %Matriks Covarian dari Kelas A
SXB = cov(XB); %Matriks Covarian dari Kelas B
SXC = cov(XC); %Matriks Covarian dari Kelas C

SumXA = sum(XA);
SumXB = sum(XB);
SumXC = sum(XC);

g=3; %Jumlah Group, (Kelas A,B,C)

GRAND_MEAN = (SumXA+SumXB+SumXC) / (g*n); %Rata'' seluruh kelas
MEAN_GRUP = [RXA; RXB; RXC];
[na, pa]= size(XA);
B = zeros(pa,pa); %Nilai awal untuk penjumlahan B
    
for i = 1:g
    b = na*(MEAN_GRUP(i,:)-GRAND_MEAN)'*(MEAN_GRUP(i,:)-GRAND_MEAN); 
    %petik = Transpose
    B = B + b;
end

W = zeros(pa, pa);
for j = 1:g %banyaknya grup
    for i = 1:na %banyaknya observasi
        W = W + (X(i, (1+(j-1)*g):(j*g))- MEAN_GRUP(j,:))' * (X(i, (1+(j-1)*g):(j*g))- MEAN_GRUP(j,:));
    end
end

total = B + W

lamda = (det(W)) / (det(B+W))


v1 = 2*pa; %pa = variabel
v2 = 3*na - pa - 2; % na = observasi
% Alpha 0.5 (ditentukan oleh peneliti)
Ftabel = finv(0.95, v1, v2) %bisa diasumsikan sebagai THRESHOLD

Fhitung = ((g*na - pa - 2)/pa) * ((1-sqrt(lamda)) / sqrt(lamda))

%Hipotesis Statistik : menguji apakah Rata" populasi 1,2,3 sama atau berbeda?
if(Fhitung < Ftabel)
    disp('Hipotesis H0 diterima')
else
    disp('Hipotesis H1 diterima')
end