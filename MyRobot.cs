
//Raimundo Jose Oliveira da Silva
//Robô desenvolvido em C# - Visual Studio 2019, submetido ao processo seletivo da empresa Solutis
//Referência: https://robocode.sourceforge.io/docs/robocode.dotnet/Index.html


using Robocode;
using System.Drawing;


namespace FNL
{
    public class MyRobot : Robot
    {
        //Método inicial do MyRobot 
        public override void Run()
        {
            //Característica/aparência do robô
            SetColors(
                Color.Black, 
                Color.Black, 
                Color.FromArgb(150, 0, 150));

            while (true)
            {
                Ahead(200);
                TurnGunRight(180);
                _ = (Rules.MAX_VELOCITY);
                TurnRight(90);
                    
            }
        }

        //Quando o MyRobot identifica um adversário 
        public override void OnScannedRobot (ScannedRobotEvent e)
        {
            //Caso a distância seja menor do que 0, variar intensidade do tiro
            if (e.Distance < 50)
            {
                Fire(Rules.MAX_BULLET_POWER);
            }
            else
            {
                Stop();
                Fire(1);
                Fire(Rules.MAX_BULLET_POWER);
            }
            
            Scan();
            
        }

        //Quando o MyRobot é atingido, revida com intensidade variada
        public void OnHitRobot(HitRobotEvent e)
        {
            //Verificando o adversário
            if (e.Bearing >= 0)
            {
                TurnRight(1);
                Back(100);
                Fire(5);
            }
            else
            {
                TurnRight(-1);
            }
            TurnRight(e.Bearing);

            //Mensurando o intesndade do tiro
            if (e.Energy > 30)
            {
                Fire(3);
            }
            else if (e.Energy > 20)
            {
                Fire(2);
            }
            else if (e.Energy > 10)
            {
                Fire(1);
            }
            else if (e.Energy > 5)
            {
                Fire(5);
            }
            //Avançando para colisão 
            Ahead(50);

        }
        

    }
}
