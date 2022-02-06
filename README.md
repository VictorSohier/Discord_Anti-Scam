# Discord_Anti-Spam

## Why is This Relevant?

There is a problem with Discord and that problem is frequent scams.

Scam links that:
- Claim you won Bitcoin (usually done in DMs, cannot be dealt with by a bot)
- Claim to be Discord itself
- Send unwanted solicitations to (legitimate or not) camgirl websites

## How do These Scams Work?

1. The scammer sends a link to a web page which requests an OAuth token to a victim
2. The link is clicked taking the user to the **legitimate** discord login page
3. This page, upon login, sends the resulting token to the scammer with full privileges

This allows the scammer to effectively take full control of your account without knowing your credentials at all and this is how the scam persists, now the scammers have fresh and trusted accounts from which more links will be automatically spread.