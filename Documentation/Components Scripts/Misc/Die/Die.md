# Die

## Why it was written

To link [[DieCause]]s with [[DieMethod]]s and provide an event that is invoked when death happens by any cause.
___

## What it does

It provides an event, OnDying. On Start, it links every [[DieCause]] this object has with its [[DieMethod]] but also queues an invoking of the OnDying event before executing the [[DieMethod]].
___

## How to use it

Simply attach to what would die. Just that.
___

***May, 2022 - initialize***
***21 Sep, 2022 - audio support***
***22 Sep, 2022 - make delegating death***
***25 Mar, 2023 - split into cause, method, and accessories*** 