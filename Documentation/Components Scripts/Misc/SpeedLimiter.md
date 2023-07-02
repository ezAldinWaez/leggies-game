# SpeedLimiter

## Why it was written

Because if we let players move as they wish, they will become rockets. Also, some things also need a speed limit.
___

## What it does

It enforces a speed limit; it will add an opposing force in Update to ensure the speed never exceeds the speed limit.

The opposing force is simulating Air Resistance: the force comes from the formula of Air Resistance:

![F_D=1/2 ρv^2 C_D A](https://latex.codecogs.com/png.image?\dpi{150}\bg{black}F_D=\frac{1}{2}\rho&space;v^2C_DA) 

And the formula of Terminal Velocity:

![V_t=√(2mg/(ρAC_D ))](https://latex.codecogs.com/png.image?\dpi{150}\bg{black}V_t=\sqrt{\frac{2mg}{\rho&space;AC_D) 

Since we want to specify the Terminal Velocity ![V_t](https://latex.codecogs.com/png.image?\bg{black}V_t) and find the opposing force ![F_D](https://latex.codecogs.com/png.image?\bg{black}F_D), we did some math and found the following:

![F_D=mgv^2/V_t^2](https://latex.codecogs.com/png.image?\dpi{150}\bg{black}F_D=mgv^2/V_t^2)

The code is much shorter than this, as it is just the formula and the reduction.
___

## How to use it

Attach it to what’s speed needs be limited and specify the max speed.
___

***25 Jun, 2022 - initialize***
***21 Sep, 2022 - change to air resistance style***
