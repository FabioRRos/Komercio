package email

import (
	"crypto/tls"
	"fmt"
	"net"
	"net/smtp"
	"strings"
)

type SMTPMailer struct {
	Host     string
	Port     string
	User     string
	Password string
}

func NewSMTPMailer(host, port, user, pass string) *SMTPMailer {
	return &SMTPMailer{Host: host, Port: port, User: user, Password: pass}
}

func (m *SMTPMailer) Send(to []string, subject string, body string) error {
	addr := net.JoinHostPort(m.Host, m.Port)

	msg := strings.Builder{}
	msg.WriteString(fmt.Sprintf("From: %s\r\n", m.User))
	msg.WriteString(fmt.Sprintf("To: %s\r\n", strings.Join(to, ", ")))
	msg.WriteString(fmt.Sprintf("Subject: %s\r\n", subject))
	msg.WriteString("MIME-Version: 1.0\r\n")
	msg.WriteString("Content-Type: text/html; charset=\"UTF-8\"\r\n")
	msg.WriteString("\r\n")
	msg.WriteString(body)

	conn, err := net.Dial("tcp", addr)
	if err != nil {
		return fmt.Errorf("falha ao conectar SMTP: %w", err)
	}

	c, err := smtp.NewClient(conn, m.Host)
	if err != nil {
		return fmt.Errorf("falha ao criar client SMTP: %w", err)
	}
	defer c.Quit()

	tlsConfig := &tls.Config{ServerName: m.Host}
	if ok, _ := c.Extension("STARTTLS"); ok {
		if err = c.StartTLS(tlsConfig); err != nil {
			return fmt.Errorf("erro no STARTTLS: %w", err)
		}
	}

	auth := smtp.PlainAuth("", m.User, m.Password, m.Host)
	if err = c.Auth(auth); err != nil {
		return fmt.Errorf("erro na autenticação SMTP: %w", err)
	}

	if err = c.Mail(m.User); err != nil {
		return err
	}
	for _, rcpt := range to {
		if err = c.Rcpt(rcpt); err != nil {
			return err
		}
	}

	w, err := c.Data()
	if err != nil {
		return err
	}
	_, err = w.Write([]byte(msg.String()))
	if err != nil {
		return err
	}
	if err = w.Close(); err != nil {
		return err
	}

	return nil
}
