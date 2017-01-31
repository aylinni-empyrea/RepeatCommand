# RepeatCommand

Executes a command at a specified interval,
or one command after a delay.

## /repeat

**Permission:** *repeatcommand*

**Usage:** `/repeat (delay) (amount) <command>`

### Execute a command multiple times

```
: /repeat 1,5 3 /heal

You've been healed!
(1,5 seconds later) You've been healed!
(1,5 seconds later) You've been healed!
```

### Run a command after a delay

```
: /repeat 5 /bc Hello

(5 seconds later) (Server Broadcast) Hello
```