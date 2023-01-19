"""Solution to the Bob exercise."""


def response(hey_bob: str) -> str:
    """Create a response from Bob, the lackadaisical teenager.

    Args:
        hey_bob (str): a message to Bob

    Returns:
        str: Bob's response
    """

    message = hey_bob.strip()
    is_question = message.endswith('?')
    is_yelling = message.isupper()
    
    if message == '':
        return 'Fine. Be that way!'

    if is_question and is_yelling:
        return 'Calm down, I know what I\'m doing!'

    if is_question:
        return 'Sure.'

    if is_yelling:
        return 'Whoa, chill out!'

    return 'Whatever.'
