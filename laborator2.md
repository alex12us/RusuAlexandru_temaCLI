Rusu Alexandru
   3133a                                              
                                                 
                                                 Tema acasa-laborator2

Cerința 1: Matricea mod de proiectare a unui obiect de tridimensional,este o matrice perspectivă.
   Am selectat matricea pe mod textură și nu mai afișează cele trei axe,ci afisează un ecran albastru. Dacă setez matricea pe mod de proiectare imi afișează cele trei axe pe ecranul albastru.

   Matricea perspectivă -cele trei axe sunt dimensiuni mari,pe ecranul afisat. Pe modul de orotgrafic prin matricea de proiectare,cele trei axe sunt mai mici.Lungimea liniei pentru fiecare axă esste mică.

   ![image](https://github.com/user-attachments/assets/e77e5e40-3491-446a-902a-cf351d245bce)
   ![image](https://github.com/user-attachments/assets/58e0477e-31aa-407f-861a-6e842d0c5957)
    

   Cerinta 3:tutorialele  OpenGL Nate Robbins
           1.Un viewport este fereastra a unui ecran în care sunt proiectate elementele grafice.Viewport-ul ca OpenGL are rolul de a plasa toate elementele grafice proiectate din sistemul de coordonate 3D în coordonatele 2D ale ecranului.
           Un viewport funcționează pe patru parametri coordonatele (x ,y),lățimea(width) și înălțimea și are rolul de acoperi întreaga fereastră,
           
      2.FPS este folosit pentru functia Run pentru a procesa mai repede,updates per second este mai important pentru 
      actualizare cadrului. FPS este folosit la
           din punct de vedere a bibliotecii OpenGL pentru a afișa rezultatul schimbând buffer-ul prin intermediul funcției 
 SwapBuffers(). Optimizarea secenei și a  tehncilor de redare face ca valoarea FPS să rămână constantă și ridicată.
           3.Metoda OnUpdateFrame() este apelată de mai multe ori pentru fiecare ciclu de execuție a programului, are rolul 
 de a actualiza logica și rulează înainte de redarea efectivă a scenei pe ecran.
           4.Modul de randare imediat(Immediate Mode Rendering) este cea mai veche tehnică de bază de randare din OpenGL. Cu 
  trecerea timpului modul de randare imediat devine irelevant pentru versiunile mai recente de OpenGL. În C#,OpenTK pentru 
  OpenGL,se folosește GL.Begin(tipul primitiv grafic) pentru a selecta una dintre primitivele 
  grafice(punct,linie,triunghi,poligoane, etc.). GL.Vertex2() și GL.Vertex3() determină fiecare punct de vârf(vertex) din 
 figură(formă geometrică). GL.Color() este folosit pentru a da culoare pentru graficul primitiv. 
           Este o ușor de învățat conceptele de bază ale graficii 3D,mai ales pnetru începători.
           5.Ultima versiue de OpenGL care acceptă modul imediat este OpenGL 3.3 Compatibility Profile.
           6.Metoda OnRenderFrame() are rolul de a desena scena pe ecran și rulează în mod repetat pentru fiecare cadru 
              afișat pe ecran după ce logica aplicației a fost actualizată in metoda OnUpdateFrame().
           7.Metoda OnResize() este nevoie să fie executată cel puțin o dată în aplicațiile OpenGL pentru a reda corect pe 
 ecran scena grafică prin ajustarea corectă viewport-ului și proiecției grafice.
           8.Parametrii metodei CreatePerspectiveFieldOfView() creează matricea de proiecție de tip perspectivă.
           Primul parametrul este fovy(Field of View) care este numită în limba română câmpul vizual vertical(unghiul de 
  deschidere al camerei),iar domeniul este (0,π) și valorile tipice pot fi (π/6,π/2). Al doilea parametru este aspectul 
 apectul ferestrei de afișare.. Raportul aspectului este între  lățimea și înălțimea pentru laturile ferestrei.Domeniul 
 pentru valoarea aspectului este în intervalul deschis la ambele capete între 0 și infinit. Valorile tipice pentru raportului 
 standard pentru ecrane sunt 4:3 și 16:9
   Al treilea parametru este zNear(Near Clipping Plane) este planul îndepărtat de tăiere și reprezintă cea mai mică distanță 
 la cere sunt vizibile obiectele. Domeniul de valori pentru zNear este (0,∞),strict pozitivă (>0).  Al patrulea parametrul 
 este zFar(Far Cliping Plane) este planul îndepărtat de tăiere și reprezintă cea mai mare distanță la care sunt vizibile 
 obiectele. Domeniul de valori este (zNear,∞) cu condiția ca zFar>zNear.  
        
